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

            Assert.AreEqual(3, request.Retries);
            Assert.AreEqual(30000, request.Timeout);
            Assert.AreEqual(HttpVerb.Get, request.Verb);
            Assert.AreEqual(UserAgent.Firefox().ToString(), request.UserAgent.ToString());

            Assert.AreEqual(0, request.Headers.Count);
            Assert.IsNotNull(request.Cookies);
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
                                  Host = "somehost.com"
                              };

            var webRequest = (HttpWebRequest) request.ToWebRequest();

            Assert.AreEqual("http://www.watchdogapp.com/", webRequest.RequestUri.ToString());

            Assert.AreEqual(5, webRequest.Headers.Count);
            Assert.AreEqual(DecompressionMethods.GZip | DecompressionMethods.Deflate, webRequest.AutomaticDecompression);
            Assert.AreEqual("GET", webRequest.Method);
            Assert.AreEqual(30000, webRequest.Timeout);
            Assert.AreEqual(UserAgent.Firefox().ToString(), webRequest.UserAgent);
            Assert.AreEqual("text/json", webRequest.ContentType);
            Assert.AreEqual("referer", webRequest.Referer);
            Assert.AreEqual("somehost.com", webRequest.Host);
            Assert.AreEqual(WebRequest.DefaultWebProxy, webRequest.Proxy);

            Assert.AreEqual("text/xml", webRequest.Accept);

            Assert.AreEqual(request.Cookies, webRequest.CookieContainer);
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

            Assert.AreEqual("Basic am9objpkb2UxMjMh", values[0]);
        }
    }
}
