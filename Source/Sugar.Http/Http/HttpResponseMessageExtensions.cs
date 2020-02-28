using System.Net.Http;
using System.Web.Http;

namespace Sugar.Http
{
    /// <summary>
    /// Extension methods for HttpResponseMessage.
    /// </summary>
    public static class HttpResponseMessageExtensions
    {
        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static string GetUrl(this HttpResponseMessage response)
        {
            return response.RequestMessage.RequestUri.AbsoluteUri;
        }

        /// <summary>
        /// Gets an exception thrown by the request.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public static HttpResponseException GetException(this HttpResponseMessage response)
        {
            HttpResponseException exception = null;

            if (!response.IsSuccessStatusCode)
            {
                exception = new HttpResponseException(response.StatusCode);
            }

            return exception;
        }
    }
}