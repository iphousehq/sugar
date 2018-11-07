using System;
using System.IO;
using System.Net;
using System.Text;
using Sugar.Mime;

namespace Sugar.Net
{
    /// <summary>
    /// Class to download content from the internet
    /// </summary>
    public class HttpService : IHttpService
    {
        /// <summary>
        /// Maps the specified <see cref="WebResponse" /> to the given <see cref="HttpResponse" />.
        /// </summary>
        /// <param name="webResponse">The web response.</param>
        /// <param name="response">The HTTP response to map the <see cref="webResponse" />to.</param>
        public static void Map(WebResponse webResponse, ref HttpResponse response)
        {
            if (webResponse != null)
            {
                response.ContentLength = webResponse.ContentLength;

                foreach (string header in webResponse.Headers)
                {
                    response.Headers.Add(header, webResponse.Headers[header]);
                }

                if (webResponse is HttpWebResponse httpWebResponse)
                {
                    response.StatusCode = httpWebResponse.StatusCode;
                    response.StatusDescription = httpWebResponse.StatusDescription;
                }

                // If the web response followed an http redirect, the URL will have changed. Reflect that change.
                response.RedirectedUrl = webResponse.ResponseUri.ToString();

                if (response.RedirectedUrl == response.Url)
                {
                    // Redirected url may be in location.
                    if (response.Headers.ContainsKey("Location"))
                    {
                        response.RedirectedUrl = response.Headers["Location"];
                    }
                }
            }
        }

        /// <summary>
        /// Downloads the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        protected virtual HttpResponse InternalDownload(HttpRequest request)
        {
            var result = new HttpResponse
                         {
                             Url = request.Url
                         };

            var webRequest = InternalBuild(request);

            // After the poodle security exploit in SSLv3 most servers are no longer supporting the SSLv3 cypher
            ServicePointManager.SecurityProtocol = request.SecurityProtocol;

            // Post request data
            if (request.Verb == HttpVerb.Post && request.Data != null)
            {
                using (var stream = webRequest.GetRequestStream())
                {
                    var encoder = new UTF8Encoding();

                    var data = encoder.GetBytes(request.Data);

                    stream.Write(data, 0, data.Length);

                    stream.Close();
                }
            }

            // Download response
            using (var webResponse = webRequest.GetResponse() as HttpWebResponse)
            {
                if (request.Verb != HttpVerb.Head)
                {
                    using (var stream = webResponse.GetResponseStream())
                    using (var memoryStream = new MemoryStream())
                    using (var reader = new BinaryReader(stream, request.Encoding))
                    using (var writer = new BinaryWriter(memoryStream, request.Encoding))
                    {
                        var buffer = new byte[2048];

                        int bytesRead;

                        do
                        {
                            bytesRead = reader.Read(buffer, 0, buffer.Length);

                            writer.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead != 0);

                        if (memoryStream.Length > 0) result.Bytes = memoryStream.ToArray();

                        result.Cookies = new CookieContainer();
                        result.Cookies.Add(webResponse.Cookies);
                    }
                }

                Map(webResponse, ref result);
            }

            return result;
        }

        /// <summary>
        /// Builds as <see cref="WebRequest"/> object from a <see cref="HttpRequest"/>.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        protected virtual WebRequest InternalBuild(HttpRequest request)
        {
            return request.ToWebRequest();
        }

        /// <summary>
        /// Builds a HTTP request from the given arguments.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public HttpRequest Build(string url, HttpVerb verb , string agent, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            var request = new HttpRequest
                          {
                              Url = url,
                              UserAgent = agent,
                              Verb = verb,
                              Referer = referer,
                              Retries = retries,
                              Timeout = timeout,
                              Encoding = encoding ?? Encoding.UTF8
                          };

            if (accept != null)
            {
                request.Accept = accept.ToString();
            }

            if (cookies != null)
            {
                request.Cookies = cookies;
            }

            return request;
        }

        /// <summary>
        /// Downloads the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public HttpResponse Download(HttpRequest request)
        {
            HttpResponse response;

            try
            {
                response = Retry.This(() => InternalDownload(request), request.Retries, request.Timeout);
            }
            catch (WebException ex)
            {
                response = new HttpResponse
                               {
                                   Exception = ex,
                                   Url = request.Url
                               };

                Map(ex.Response, ref response);

                // .NET Core does not auto-redirect in some cases (e.g. redirect changes protocol from HTTP -> HTTPS)
                // In this case an exception will be thrown
                // If this is the case then check for 3XX HTTP status codes AND if the AllowAutoRedirect setting is on
                // If so then get re-download the redirected url request
                // (Make sure we don't redirect too many times)
                if ((response.StatusCode == HttpStatusCode.Moved ||
                     response.StatusCode == HttpStatusCode.MovedPermanently ||
                     response.StatusCode == HttpStatusCode.Found ||
                     response.StatusCode == HttpStatusCode.Redirect ||
                     response.StatusCode == HttpStatusCode.RedirectMethod ||
                     response.StatusCode == HttpStatusCode.TemporaryRedirect) && request.AllowAutoRedirect)
                {
                    if (request.CurrentRedirects < request.MaximumRedirects)
                    {
                        request.Url = response.RedirectedUrl;
                        request.CurrentRedirects++;
                        response = Download(request);
                    }
                }
            }
            catch (Exception ex)
            {
                response = new HttpResponse
                               {
                                   Exception = ex,
                                   Url = request.Url
                               };
            }

            return response;
        }

        /// <summary>
        /// Downloads the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        /// <remarks>
        /// Will retry to download 3 times by default.
        /// </remarks>
        public HttpResponse Download(string url, HttpVerb verb, string agent, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            var request = Build(url, verb, agent, cookies, referer, retries, timeout, accept, encoding);

            return Download(request);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public HttpResponse Get(string url, string agent, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            return Download(url, HttpVerb.Get, agent, cookies, referer, retries, timeout, accept, encoding);
        }

        /// <summary>
        /// POSTs to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public HttpResponse Post(string url, string agent, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            return Download(url, HttpVerb.Post, agent, cookies, referer, retries, timeout, accept, encoding);
        }

        /// <summary>
        /// Gets the HEAD of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public HttpResponse Head(string url, string agent, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            return Download(url, HttpVerb.Head, agent, cookies, referer, retries, timeout, accept, encoding);
        }

        /// <summary>
        /// Creates an <see cref="HttpQuery"/> object.
        /// </summary>
        /// <returns></returns>
        public HttpQuery Query()
        {
            return new HttpQuery(this);
        }
    }
}
