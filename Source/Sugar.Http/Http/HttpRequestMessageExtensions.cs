using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Sugar.Http
{
    /// <summary>
    /// Extension methods for <see cref="HttpRequestMessage"/>
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        /// Sets the HTTP request accept header to HTML.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <returns>HttpRequestMessage.</returns>
        public static HttpRequestMessage SetAcceptHeaderToHtml(this HttpRequestMessage req)
        {
            req.Headers.Accept.TryParseAdd("text/html");

            return req;
        }

        /// <summary>
        /// Sets the HTTP request accept header to JSON.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <returns>HttpRequestMessage.</returns>
        public static HttpRequestMessage SetAcceptHeaderToJson(this HttpRequestMessage req)
        {
            req.Headers.Accept.TryParseAdd("application/json");

            return req;
        }

        /// <summary>
        /// Sets the accept encoding HTTP header to accept compressed responses e.g. gzip, deflate.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <returns>HttpRequestMessage.</returns>
        public static HttpRequestMessage SetAcceptEncodingToCompressed(this HttpRequestMessage req)
        {
            req.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("br", 1.0));
            req.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip", 0.75));
            req.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("compress", 0.75));
            req.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate", 0.50));
            
            return req;
        }

        /// <summary>
        /// Sets the accept language HTTP header to US English.
        /// </summary>
        /// <param name="req">The req.</param>
        /// <returns>HttpRequestMessage.</returns>
        public static HttpRequestMessage SetAcceptLanguageToUsEnglish(this HttpRequestMessage req)
        {
            req.Headers.AcceptLanguage.TryParseAdd("en-US");
            req.Headers.AcceptLanguage.TryParseAdd("en");

            return req;
        }
    }
}