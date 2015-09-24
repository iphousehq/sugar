using System;
using System.Net.Http;

namespace Sugar.Http
{
    /// <summary>
    /// Helper class to easily get a new instance of a <see cref="HttpClient"/>.
    /// </summary>
    /// <remarks>
    /// Only one instance of <see cref="HttpClient"/> should be used per request: 
    /// If you stick to one instance of HTTP client and change its Timeout setting after a fist request was issued an exception will be thrown.
    /// </remarks>
    public class HttpClientProvider : IHttpClientProvider
    {
        /// <summary>
        /// Gets or sets the message handler.
        /// </summary>
        /// <value>
        /// The message handler.
        /// </value>
        public HttpMessageHandler MessageHandler { get; set; }

        /// <summary>
        /// Hook to set default settings on the HTTP client that <see cref="HttpClient"/> returns.
        /// </summary>
        /// <value>
        /// The initialise with.
        /// </value>
        public Action<HttpClient> InitialiseWith { get; set; }

        /// <summary>
        /// Gets the HTTP client.
        /// </summary>
        /// <value>
        /// The HTTP client.
        /// </value>
        public HttpClient HttpClient
        {
            get
            {
                var client = MessageHandler == null
                    ? new HttpClient()
                    : new HttpClient(MessageHandler);

                if (InitialiseWith != null)
                {
                    InitialiseWith(client);
                }

                return client;
            }
        }
    }
}

