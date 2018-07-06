using System.Net.Http;
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
        /// Configures the HTTP client factory that returns a client with a mocked handler.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>The mock HTTP message handler</returns>
        public static MockHttpMessageHandler ConfigureMockHttpClient(this MockContext context)
        {
            context.AddMock<IAccessor<HttpClient>>();

            var mockHttp = new MockHttpMessageHandler();

            context.Get<IAccessor<HttpClient>>()
                .Setup(call => call.Access())
                .Returns(mockHttp.ToHttpClient());

            return mockHttp;
        }
    }
}