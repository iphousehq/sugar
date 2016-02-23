using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class UserAgentTest
    {
        [Test]
        public void TestUserAgents()
        {
            Assert.AreEqual("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)", UserAgent.InternetExplorer().ToString());
            Assert.AreEqual("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.0000.000 Safari/537.36", UserAgent.Chrome().ToString());
            Assert.AreEqual("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Safari/537.36 Edge/12.000", UserAgent.Edge().ToString());
            Assert.AreEqual("Mozilla/5.0 (Windows NT 6.3; WOW64; rv:41.0) Gecko/20100101 Firefox/41.0", UserAgent.Firefox().ToString());
            Assert.AreEqual("Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_3 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8J2 Safari/6533.18.5", UserAgent.Iphone().ToString());
            Assert.AreEqual("Mozilla/5.0 (BlackBerry; U; BlackBerry 9900; en-US) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.0.0 Mobile Safari/534.11+", UserAgent.Blackberry().ToString());
            Assert.AreEqual("test", UserAgent.Custom("test").ToString());
        }
    }
}
