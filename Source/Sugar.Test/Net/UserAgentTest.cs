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
            Assert.AreEqual("Mozilla/5.0 (Windows NT 5.0; rv:5.0) Gecko/20100101 Firefox/5.0", UserAgent.Firefox().ToString());
            Assert.AreEqual("Mozilla/5.0 (Windows; U; Windows NT 5.2; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/13.0.782.43 Safari/535.1", UserAgent.Chrome().ToString());
            Assert.AreEqual("test", UserAgent.Custom("test").ToString());
        }
    }
}
