using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class UrlWithSubdomainTest
    {
        [Test]
        public void TestDomainSansSubDomains()
        {
            var url = new UrlWithSubdomain("http://www.news.bbc.co.uk/");

            Assert.AreEqual("bbc.co.uk", url.DomainSansSubDomain);
        }

        [Test]
        public void TestSingleDomainSansSubDomains()
        {
            var url = new UrlWithSubdomain("http://stackoverflow.com/");

            Assert.AreEqual("stackoverflow.com", url.DomainSansSubDomain);
        }

        [Test]
        public void TestLongDomainSansSubDomains()
        {
            var url = new UrlWithSubdomain("http://www.sales.stores.ebay.co.uk/");

            Assert.AreEqual("ebay.co.uk", url.DomainSansSubDomain);
        }

        [Test]
        public void TestNoDomainSansSubDomains()
        {
            var url = new UrlWithSubdomain("http:///search?id=50");

            Assert.AreEqual(string.Empty, url.DomainSansSubDomain);
        }

    }
}