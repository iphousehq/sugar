using System.Net;
using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class HttpRequestTest
    {
        [Test]
        public void TestConstructor()
        {
            var request = new HttpRequest();

            Assert.That(request.Retries, Is.EqualTo(3));
            Assert.That(request.Timeout, Is.EqualTo(30000));
            Assert.That(request.Verb, Is.EqualTo(HttpVerb.Get));

            Assert.That(request.Headers.Count, Is.EqualTo(0));
            Assert.That(request.Cookies, Is.Not.Null);
        }

        [Test]
        public void TestToWebRequest()
        {
            var request = new HttpRequest
                          {
                              Url = "http://www.watchdogapp.com",
                              ContentType = "text/json",
                              Accept = "text/xml",
                              Referer = "referer",
                              Host = "somehost.com",
                              UserAgent = "Mozilla/5.0 (Windows NT 6.3; WOW64; rv:41.0) Gecko/20100101 Firefox/41.0"
                          };

            var webRequest = (HttpWebRequest) request.ToWebRequest();

            Assert.That(webRequest.RequestUri.ToString(), Is.EqualTo("http://www.watchdogapp.com/"));

            Assert.That(webRequest.Headers.Count, Is.EqualTo(5));
            Assert.That(webRequest.AutomaticDecompression, Is.EqualTo(DecompressionMethods.GZip | DecompressionMethods.Deflate));
            Assert.That(webRequest.Method, Is.EqualTo("GET"));
            Assert.That(webRequest.Timeout, Is.EqualTo(30000));
            Assert.That(webRequest.UserAgent, Is.EqualTo("Mozilla/5.0 (Windows NT 6.3; WOW64; rv:41.0) Gecko/20100101 Firefox/41.0"));
            Assert.That(webRequest.ContentType, Is.EqualTo("text/json"));
            Assert.That(webRequest.Referer, Is.EqualTo("referer"));
            Assert.That(webRequest.Host, Is.EqualTo("somehost.com"));
            Assert.That(webRequest.Proxy, Is.EqualTo(WebRequest.DefaultWebProxy));

            Assert.That(webRequest.Accept, Is.EqualTo("text/xml"));

            Assert.That(webRequest.CookieContainer, Is.EqualTo(request.Cookies));
        }

        [Test]
        public void TestToWebRequestWithAutentication()
        {
            var request = new HttpRequest
                          {
                              Url = "http://www.watchdogapp.com",
                              UseBasicAuthentication = true,
                              Username = "john",
                              Password = "doe123!",
                              Host = "somehost.com"
                          };

            var webRequest = (HttpWebRequest)request.ToWebRequest();

            var values = webRequest.Headers.GetValues("Authorization");

            Assert.That(values[0], Is.EqualTo("Basic am9objpkb2UxMjMh"));
        }
    }
}
