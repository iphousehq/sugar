using System.Net.Http;
using NUnit.Framework;

namespace Sugar.Http
{
    [TestFixture]
    [Parallelizable]
    public class HttpRequestMessageExtensionsTest
    {
        [Test]
        public void TestSetAcceptHeaderToHtml()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptHeaderToHtml();

            Assert.That(req.Headers.Accept.ToString(), Is.EqualTo("text/html"));
        }

        [Test]
        public void TestSetAcceptHeaderToJson()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptHeaderToJson();

            Assert.That(req.Headers.Accept.ToString(), Is.EqualTo("application/json"));
        }

        [Test]
        public void TestSetAcceptEncodingToCompressed()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptEncodingToCompressed();

            var value = req.Headers.AcceptEncoding.ToString();

            Assert.That(value, Is.EqualTo("br; q=1.0, gzip; q=0.75, compress; q=0.75, deflate; q=0.5"));
        }
        
        [Test]
        public void TestSetAcceptLanguageToUsEnglish()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptLanguageToUsEnglish();

            Assert.That(req.Headers.AcceptLanguage.ToString(), Is.EqualTo("en-US, en"));
        }
    }
}
