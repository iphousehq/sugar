using System;
using System.Net.Http;

namespace Sugar.Http
{
    /// <summary>
    /// Interface to provide a HTTP client
    /// </summary>
    [Obsolete("About to be replaced by Microsoft's IHttpClientFactory that plays nice with Polly")]
    public interface IHttpClientProvider
    {
        /// <summary>
        /// Gets a new instance of <see cref="HttpClient" />.
        /// </summary>
        /// <param name="configureRetryIntercept">if set to <c>true</c> [configure the retry intercept].</param>
        /// <returns></returns>
        HttpClient Create(bool configureRetryIntercept = true);

        /// <summary>
        /// Gets a new instance of <see cref="HttpClient" />.
        /// </summary>
        /// <param name="innerMessageHandler">The inner message handler (optional).</param>
        /// <param name="configureRetryIntercept">if set to <c>true</c> [configure the retry intercept].</param>
        /// <returns></returns>
        HttpClient Create(HttpMessageHandler innerMessageHandler, bool configureRetryIntercept = true);
    }
}
