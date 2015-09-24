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

            var client1 = provider.HttpClient;
            var client2 = provider.HttpClient;

            Assert.AreNotSame(client1, client2);
        }

        private class FakeHandler : HttpMessageHandler
        {
            public int SendCount;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                SendCount++;

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        [Test]
        public async void TestHttpClientWithMessageHandler()
        {
            var handler = new FakeHandler();

            var provider = new HttpClientProvider
            {
                MessageHandler = handler
            };

            var client = provider.HttpClient;

            var request = new HttpRequestMessage(HttpMethod.Get, "http://hello.com/world");

            await client.SendAsync(request);

            Assert.AreEqual(1, handler.SendCount);
        }

        [Test]
        public void TestHttpClientWithCustomInitialisation()
        {
            var provider = new HttpClientProvider
            {
                InitialiseWith = (c) => c.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Test", "1.0"))
            };

            var client = provider.HttpClient;

            Assert.AreEqual("Test/1.0", client.DefaultRequestHeaders.UserAgent.ToString());
        }
    }
}
