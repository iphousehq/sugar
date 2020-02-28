using System.Net;
using System.Net.Http;
using NUnit.Framework;

namespace Sugar.Http
{
    [TestFixture]
    public class HttpResponseMessageExtensionsTest
    {
        [Test]
        public void TestGetUrl()
        {
            var response = new HttpResponseMessage {RequestMessage = new HttpRequestMessage(HttpMethod.Get, "https://www.test.com")};

            Assert.AreEqual("https://www.test.com/", response.GetUrl());
        }

        [Test]
        public void TestGetExceptionWhenNotError()
        {
            var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };

            Assert.Null(response.GetException());
        }

        [Test]
        public void TestGetException()
        {
            var response = new HttpResponseMessage {StatusCode = HttpStatusCode.BadRequest};

            Assert.AreEqual(HttpStatusCode.BadRequest, response.GetException().Response.StatusCode);
        }
    }
}