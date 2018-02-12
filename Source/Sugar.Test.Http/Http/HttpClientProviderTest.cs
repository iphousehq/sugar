using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Sugar.Http
{
    public class HttpClientProviderTest
    {
        [Fact]
        public void TestHttpClientAlwaysReturnsNewInstance()
        {
            var provider = new HttpClientProvider();

            var client1 = provider.Create();
            var client2 = provider.Create();

            Assert.NotSame(client1, client2);
        }

        [Fact]
        public void TestHttpClientWithCustomInitialisation()
        {
            var provider = new HttpClientProvider
            {
                InitialiseWith = c => c.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Test", "1.0"))
            };

            var client = provider.Create();

            Assert.Equal("Test/1.0", client.DefaultRequestHeaders.UserAgent.ToString());
        }

        private class FakeHandler : HttpMessageHandler
        {
            public int RequestCount = 0;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestCount++;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        [Fact]
        public void TestHttpClientWithRetryIntercept()
        {
            var interceptCount = 0;

            var innerHandler = new FakeHandler();

            var provider = new HttpClientProvider
            {
                RetryIntercept = delegate
                {
                    interceptCount++;
                    return Task.FromResult(false);
                }
            };

            var client = provider.Create(innerHandler);

            client.GetAsync("http://hello.world/boo");

            Assert.Equal(1, interceptCount);
            Assert.Equal(1, innerHandler.RequestCount);
        }

        [Fact]
        public void TestHttpClientWithRetryInterceptWhenShouldRetry()
        {
            var interceptCount = 0;

            var innerHandler = new FakeHandler();

            var provider = new HttpClientProvider
            {
                RetryIntercept = delegate
                {
                    interceptCount++;
                    return Task.FromResult(true);
                }
            };

            var client = provider.Create(innerHandler);

            client.GetAsync("http://hello.world/boo");

            Assert.Equal(1, interceptCount);
            Assert.Equal(2, innerHandler.RequestCount);
        }

        [Fact]
        public void TestHttpClientWithRetryInterceptWithRetryInterceptSetButShouldNotRetry()
        {
            var interceptCount = 0;

            var innerHandler = new FakeHandler();

            var provider = new HttpClientProvider
            {
                RetryIntercept = delegate
                {
                    interceptCount++;
                    return Task.FromResult(true);
                }
            };

            var client = provider.Create(innerHandler, false);

            client.GetAsync("http://hello.world/boo");

            Assert.Equal(0, interceptCount);
            Assert.Equal(1, innerHandler.RequestCount);
        }
    }
}
