using System.Net.Http;
using NUnit.Framework;

namespace Sugar.Http
{
    [TestFixture]
    public class HttpRequestMessageExtensionsTest
    {
        [Test]
        public void TestSetAcceptHeaderToHtml()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptHeaderToHtml();

            Assert.AreEqual("text/html", req.Headers.Accept.ToString());
        }

        [Test]
        public void TestSetAcceptHeaderToJson()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptHeaderToJson();

            Assert.AreEqual("application/json", req.Headers.Accept.ToString());
        }

        [Test]
        public void TestSetAcceptEncodingToCompressed()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptEncodingToCompressed();

            Assert.AreEqual("gzip, deflate", req.Headers.AcceptEncoding.ToString());
        }

        [Test]
        public void TestSetAcceptLanguageToUsEnglish()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptLanguageToUsEnglish();

            Assert.AreEqual("en-US, en", req.Headers.AcceptLanguage.ToString());
        }
    }
}