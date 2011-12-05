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
            Assert.AreEqual("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:8.0.1) Gecko/20100101 Firefox/8.0.1", UserAgent.Firefox().ToString());
            Assert.AreEqual("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2", UserAgent.Chrome().ToString());
            Assert.AreEqual("test", UserAgent.Custom("test").ToString());
        }
    }
}
