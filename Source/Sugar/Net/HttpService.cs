using System;
using System.IO;
using System.Net;
using System.Text;

namespace Sugar.Net
{
    /// <summary>
    /// Class to download content from the internet
    /// </summary>
    public class HttpService : IHttpService
    {
        /// <summary>
        /// Downloads the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        private static HttpResponse InternalDownload(HttpRequest request)
        {
            var result = new HttpResponse
                             {
                                 Url = request.Url,
                                 UserAgent = request.UserAgent
                             };

            var webRequest = request.ToWebRequest();

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
            using (var response = webRequest.GetResponse() as HttpWebResponse)
            using (var stream = response.GetResponseStream())
            using (var memoryStream = new MemoryStream())
            {
                var buffer = new byte[2048];

                int bytesRead;

                do
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);

                    memoryStream.Write(buffer, 0, bytesRead);
                }
                while (bytesRead != 0);

                if (memoryStream.Length > 0) result.Bytes = memoryStream.ToArray();

                result.Cookies = new CookieContainer();
                result.Cookies.Add(response.Cookies);
            }

            return result;
        }

        public HttpRequest Build(string url, HttpVerb verb = HttpVerb.Get, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500)
        {
            var request = new HttpRequest
            {
                Url = url,
                UserAgent = agent ?? UserAgent.Firefox(),
                Verb = verb,
                Referer = referer,
                Retries = retries,
                Timeout = timeout
            };

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
        /// <returns></returns>
        /// <remarks>
        /// Will retry to download 3 times by default.
        /// </remarks>
        public HttpResponse Download(string url, HttpVerb verb = HttpVerb.Get, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500)
        {
            if (agent == null) agent = UserAgent.Firefox();

            var request = Build(url, verb, agent, cookies, referer, retries, timeout);

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
        /// <returns></returns>
        public HttpResponse Get(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500)
        {
            return Download(url, HttpVerb.Get, agent, cookies, referer, retries, timeout);
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
        /// <returns></returns>
        public HttpResponse Post(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500)
        {
            return Download(url, HttpVerb.Post, agent, cookies, referer, retries, timeout);
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
        /// <returns></returns>
        public HttpResponse Head(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500)
        {
            return Download(url, HttpVerb.Post, agent, cookies, referer, retries, timeout);
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
