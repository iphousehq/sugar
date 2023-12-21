using System.Net.Http;
using System.Threading.Tasks;
using LightInject;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using Sugar.Core;

namespace Sugar.Moq
{
    [TestFixture]
    public class HttpClientMockContextExtensionsTest
    {
        [Test]
        public async Task TestRegisterMockHttp()
        {
            var serviceContainer = new ServiceContainer();

            var mockHttp = new MockHttpMessageHandler();

            var result = serviceContainer.RegisterMockHttp(mockHttp);

            Assert.That(result, Is.SameAs(serviceContainer));

            var httpClientAccessor = serviceContainer.GetInstance<IAccessor<HttpClient>>();
            
            var httpClient = httpClientAccessor.Access();

            mockHttp.When(HttpMethod.Get, "http://foo.bar/hello")
                    .Respond(new StringContent("world"));

            var response = await httpClient.GetStringAsync("http://foo.bar/hello");

            Assert.That(response, Is.EqualTo("world"));
        }
    }
}
