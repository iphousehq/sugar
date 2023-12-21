using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sugar.Http
{
    [TestFixture]
    public class HttpClientProviderTest
    {
        [Test]
        public void TestHttpClientAlwaysReturnsNewInstance()
        {
            var provider = new HttpClientProvider();

            var client1 = provider.Create();
            var client2 = provider.Create();

            Assert.That(client2, Is.Not.SameAs(client1));
        }

        [Test]
        public void TestHttpClientWithCustomInitialisation()
        {
            var provider = new HttpClientProvider
                           {
                               InitialiseWith = c => c.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Test", "1.0"))
                           };

            var client = provider.Create();

            Assert.That(client.DefaultRequestHeaders.UserAgent.ToString(), Is.EqualTo("Test/1.0"));
        }

        private class FakeHandler : HttpMessageHandler
        {
            public int RequestCount;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                RequestCount++;
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        [Test]
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

            Assert.That(interceptCount, Is.EqualTo(1));
            Assert.That(innerHandler.RequestCount, Is.EqualTo(1));
        }

        [Test]
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

            Assert.That(interceptCount, Is.EqualTo(1));
            Assert.That(innerHandler.RequestCount, Is.EqualTo(2));
        }

        [Test]
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

            Assert.That(interceptCount, Is.EqualTo(0));
            Assert.That(innerHandler.RequestCount, Is.EqualTo(1));
        }
    }
}
