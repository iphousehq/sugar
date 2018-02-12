using System.Net.Http;
using Xunit;

namespace Sugar.Http
{
    public class HttpRequestMessageExtensionsTest
    {
        [Fact]
        public void TestSetAcceptHeaderToHtml()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptHeaderToHtml();

            Assert.Equal("text/html", req.Headers.Accept.ToString());
        }

        [Fact]
        public void TestSetAcceptHeaderToJson()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptHeaderToJson();

            Assert.Equal("application/json", req.Headers.Accept.ToString());
        }

        [Fact]
        public void TestSetAcceptEncodingToCompressed()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptEncodingToCompressed();

            Assert.Equal("gzip, deflate", req.Headers.AcceptEncoding.ToString());
        }

        [Fact]
        public void TestSetAcceptLanguageToUsEnglish()
        {
            var req = new HttpRequestMessage();

            req.SetAcceptLanguageToUsEnglish();

            Assert.Equal("en-US, en", req.Headers.AcceptLanguage.ToString());
        }
    }
}