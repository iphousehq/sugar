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
            var response = service.Head("http://www.watchdogapp.com/");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.IsNull(response.Bytes);

            Assert.AreEqual(-1, response.ContentLength);
        }

        [Test]
        public void TestGet()
        {
            var response = service.Get("http://www.watchdogapp.com/");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.Less(0, response.Bytes.Length);

            Assert.AreEqual(-1, response.ContentLength);
        }

        [Test]
        public void TestGet404Answer()
        {
            var response = service.Get("http://comsechq.com/404");

            var notFound = response.StatusCode == HttpStatusCode.NotFound;

            Assert.IsTrue(notFound);

            Assert.Less(0, response.Headers.Count);

            Assert.IsNull(response.Bytes);

            Assert.Less(0, response.ContentLength);
        }
    }
}
