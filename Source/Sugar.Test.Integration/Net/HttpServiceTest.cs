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
            var response = service.Head("http://www.bbc.co.uk/");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.IsNull(response.Bytes);

            Assert.AreEqual(-1, response.ContentLength);
        }

        [Test]
        public void TestGet()
        {
            var response = service.Get("http://arstechnica.com/");

            Assert.IsTrue(response.Success);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.Less(0, response.Bytes.Length);

            Assert.AreEqual(-1, response.ContentLength);
        }

        [Test]
        public void TestGet404Answer()
        {
            var response = service.Get("http://github.com/does-no-exist");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);

            Assert.Less(0, response.Headers.Count);

            Assert.IsNull(response.Bytes);

            Assert.LessOrEqual(-1, response.ContentLength);
        }

        [Test]
        public void TestPostWithoutBody()
        {
            var response = service.Post("http://httpbin.org/post ");

            Assert.True(response.Success);
        }
    }
}
