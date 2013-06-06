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
        /// Maps the specified <see cref="WebResponse"/> to the given <see cref="HttpResponse"/>.
        /// </summary>
        /// <param name="webResponse">The web response.</param>
        /// <param name="response">The HTTP response.</param>
        /// <returns>the given HTTP response.</returns>
        public static HttpResponse Map(WebResponse webResponse, HttpResponse response)
        {
            if (webResponse != null)
            {
                response.ContentLength = webResponse.ContentLength;

                foreach (string header in webResponse.Headers)
                {
                    response.Headers.Add(header, webResponse.Headers[header]);
                }

                var httpWebResponse = webResponse as HttpWebResponse;
                if (httpWebResponse != null)
                {
                    response.StatusCode = httpWebResponse.StatusCode;
                    response.StatusDescription = httpWebResponse.StatusDescription;
                }
            }

            return response;
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
                                 Url = request.Url,
                                 UserAgent = request.UserAgent
                             };

            var webRequest = InternalBuild(request);

            // Post request data
            if (request.Verb == HttpVerb.Post)
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

                result = Map(webResponse, result);
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
        public HttpRequest Build(string url, HttpVerb verb = HttpVerb.Get, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            var request = new HttpRequest
            {
                Url = url,
                UserAgent = agent ?? UserAgent.Firefox(),
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
                                   Url = request.Url,
                                   UserAgent = request.UserAgent
                               };

                response = Map(ex.Response, response);
            }
            catch (Exception ex)
            {
                response = new HttpResponse
                               {
                                   Exception = ex,
                                   Url = request.Url,
                                   UserAgent = request.UserAgent
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
        public HttpResponse Download(string url, HttpVerb verb = HttpVerb.Get, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            if (agent == null) agent = UserAgent.Firefox();

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
        public HttpResponse Get(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            return Download(url, HttpVerb.Get, agent, cookies, referer, retries, timeout, accept, encoding);
        }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public HttpResponse Get(string url)
        {
            return Get(url, null);
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
        /// <returns></returns>
        public HttpResponse Post(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            return Download(url, HttpVerb.Post, agent, cookies, referer, retries, timeout, accept, encoding);
        }

        /// <summary>
        /// POSTs to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public HttpResponse Post(string url)
        {
            return Post(url, null);
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
        public HttpResponse Head(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 10000, BaseMime accept = null, Encoding encoding = null)
        {
            return Download(url, HttpVerb.Head, agent, cookies, referer, retries, timeout, accept, encoding);
        }

        /// <summary>
        /// Gets the HEAD of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public HttpResponse Head(string url)
        {
            return Head(url, null);
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
