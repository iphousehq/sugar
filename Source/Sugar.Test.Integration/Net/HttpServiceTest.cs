using System.Net;
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
            var response = service.Head("https://www.bbc.co.uk", string.Empty);

            Assert.That(response.Success, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(response.Headers.Count, Is.GreaterThan(0));;

            Assert.That(response.Bytes, Is.Null);
        }

        [Test]
        public void TestGet()
        {
            var response = service.Get("https://www.facebook.com/", string.Empty);

            Assert.That(response.Success, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(response.Headers.Count, Is.GreaterThan(0));;

            Assert.That(response.Bytes.Length, Is.GreaterThan(0));;
        }

        [Test]
        public void TestGetWithRedirection()
        {
            var response = service.Get("http://github.com", string.Empty);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Url, Is.EqualTo("http://github.com"));
            Assert.That(response.RedirectedUrl, Is.EqualTo("https://github.com/"));
            Assert.That(response.WasRedirected, Is.True);
        }

        [Test]
        public void TestGetHttps()
        {
            var response = service.Get("https://www.google.com/", string.Empty);

            Assert.That(response.Success, Is.True);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            Assert.That(response.Headers.Count, Is.GreaterThan(0));;

            Assert.That(response.Bytes.Length, Is.GreaterThan(0));;
        }

        [Test]
        public void TestGet404Answer()
        {
            var response = service.Get("https://github.com/does-no-exist", string.Empty);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

            Assert.That(response.Headers.Count, Is.GreaterThan(0));;

            Assert.That(response.Bytes, Is.Null);
        }

        [Test]
        public void TestPostWithoutBody()
        {
            var response = service.Post("https://httpbin.org/post", string.Empty);

            Assert.That(response.Success, Is.True);
        }
    }
}
