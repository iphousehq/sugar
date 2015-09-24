using System.Net.Http;

namespace Sugar.Http
{
    /// <summary>
    /// Interface to provide a HTTP client
    /// </summary>
    public interface IHttpClientProvider
    {
        /// <summary>
        /// Gets or sets the message handler.
        /// </summary>
        /// <value>
        /// The message handler.
        /// </value>
        HttpMessageHandler MessageHandler { get; set; }

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <value>
        /// The HTTP client.
        /// </value>
        HttpClient HttpClient { get; }
    }
}