using System.Net;
using System.Text;
using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class HttpServiceTest
    {
        private HttpService service;

        [SetUp]
        public void Setup()
        {
            service = new HttpService();
        }

        [Test]
        public void TestHead()
        {
            var response = service.Head("http://www.bbc.co.uk", string.Empty);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.IsNull(response.Bytes);
        }

        [Test]
        public void TestGet()
        {
            var response = service.Get("http://arstechnica.com/", string.Empty);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.Less(0, response.Bytes.Length);
        }

        [Test]
        public void TestGetWithRedirection()
        {
            var response = service.Get("http://github.com", string.Empty);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("http://github.com", response.Url);
            Assert.AreEqual("https://github.com/", response.RedirectedUrl);
            Assert.IsTrue(response.WasRedirected);
        }

        [Test]
        public void TestGetHttps()
        {
            var response = service.Get("https://arstechnica.com/", string.Empty);

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.Less(0, response.Bytes.Length);
        }

        [Test]
        public void TestGet404Answer()
        {
            var response = service.Get("https://github.com/does-no-exist", string.Empty);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.IsNull(response.Bytes);
        }
        
        [Test]
        public void TestPostWithoutBody()
        {
            var response = service.Post("http://httpbin.org/post", string.Empty);

            Assert.True(response.Success);
        }

        [Test]
        public void TestGetWhenRedirectedFromHttpsToHttp()
        {
            var request = new HttpRequest
                          {
                              Url = "https://detail.1688.com/offer/949129641.html",
                              Verb = HttpVerb.Get,
                              Accept = "text/html,application/xhtml+xml,application/xml",
                              UserAgent = "Mozilla/5.0 (Windows NT 5.0; rv:21.0) Gecko/20100101 Firefox/21.0",
                              AllowAutoRedirect = true,
                              Encoding = Encoding.UTF8,
                              Host = "detail.1688.com",
                              KeepAlive = false,
                              Retries = 0,
                              Timeout = 60000
                          };

            var response = service.Download(request);

            Assert.False(response.Success);
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
