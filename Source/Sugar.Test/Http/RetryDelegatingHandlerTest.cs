using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Sugar.Http
{
    [TestFixture]
    public class RetryDelegatingHandlerTest
    {
        private class FakeHandler : HttpMessageHandler
        {
            public int FailedCount;
            public int AuthorizationAttempts;
            public int OkCount;

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (AuthorizationAttempts == 0)
                {
                    if (request.RequestUri.PathAndQuery.Contains("authorize"))
                    {
                        AuthorizationAttempts++;

                        return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
                    }

                    FailedCount++;
                    return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
                }

                OkCount++;

                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
            }
        }

        [Test]
        public async Task TestHttpClientWithoutIntercept()
        {
            var innerHandler = new FakeHandler();

            var retryHandler = new RetryDelegatingHandler
                               {
                                   InnerHandler = innerHandler
                               };

            var client = new HttpClient(retryHandler);

            var response = await client.GetAsync("http://hello.world/test");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Unauthorized));

            Assert.That(innerHandler.FailedCount, Is.EqualTo(1));
            Assert.That(innerHandler.AuthorizationAttempts, Is.EqualTo(0));
            Assert.That(innerHandler.OkCount, Is.EqualTo(0));
        }

        [Test]
        public async Task TestHttpClientWithRetryIntercept()
        {
            // The fake handler lets us track the number of 'actual' requests
            var innerHandler = new FakeHandler();

            var retryHandler = new RetryDelegatingHandler
                               {
                                   InnerHandler = innerHandler,
                                   RetryIntercept = async delegate(HttpResponseMessage responseMessage)
                                                    {
                                                        if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                                                        {
                                                            // Predent we authenticate
                                                            var retryClient = new HttpClient(innerHandler);

                                                            var authorizeResponse = await retryClient.GetAsync("http://hello.world/authorize?a=bcd");

                                                            return authorizeResponse.IsSuccessStatusCode;
                                                        }

                                                        return false;
                                                    }
                               };

            var client = new HttpClient(retryHandler);

            var response = await client.GetAsync("http://hello.world/test");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(innerHandler.FailedCount, Is.EqualTo(1));
            Assert.That(innerHandler.AuthorizationAttempts, Is.EqualTo(1));
            Assert.That(innerHandler.OkCount, Is.EqualTo(1));
        }
    }
}
