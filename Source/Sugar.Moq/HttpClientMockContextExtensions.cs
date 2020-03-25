using System.Net.Http;
using LightInject;
using Moq;
using RichardSzalay.MockHttp;
using Sugar.Core;

namespace Sugar.Moq
{
    /// <summary>
    /// Extension methods to help test classes that rely on <see cref="HttpClient"/>.
    /// </summary>
    public static class HttpClientMockContextExtensions
    {
        /// <summary>
        /// Registered an HTTP client factory that returns a client with a mocked handler.
        /// </summary>
        /// <param name="container">The service container.</param>
        /// <param name="mockHttp">The <see cref="MockHttpMessageHandler" /> instance to register</param>
        /// <returns>The mock HTTP message handler</returns>
        public static IServiceContainer RegisterMockHttp<T>(this IServiceContainer container, T mockHttp)
            where T : MockHttpMessageHandler
        {
            var mockedHttpClientAccessor = new Mock<IAccessor<HttpClient>>();

            container.RegisterInstance<IAccessor<HttpClient>>(mockedHttpClientAccessor.Object);

            mockedHttpClientAccessor.Setup(call => call.Access())
                                    .Returns(mockHttp.ToHttpClient());

            return container;
        }
    }
}