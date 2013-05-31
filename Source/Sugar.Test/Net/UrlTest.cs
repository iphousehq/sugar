using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class UrlTest
    {
        [Test]
        public void TestNullUrl()
        {
            var url = new Url(null);

            Assert.IsFalse(url.IsValid);
            Assert.AreEqual(string.Empty, url.ToString());
        }

        [Test]
        public void TestEmptyUrl()
        {
            var url = new Url(string.Empty);

            Assert.IsFalse(url.IsValid);
            Assert.AreEqual(string.Empty, url.ToString());
        }

        [Test]
        public void TestInvalidUrl()
        {
            var url = new Url("i'm invalid");

            Assert.IsFalse(url.IsValid);
            Assert.AreEqual(string.Empty, url.ToString());
        }

        [Test]
        public void TestValidUrl()
        {
            var url = new Url("http://watchdogapp.com/folder1/page1.html");

            Assert.IsTrue(url.IsValid);
            Assert.AreEqual("http://watchdogapp.com/folder1/page1.html", url.ToString());

            url = new Url("http://gizmodo.com/5678421/11+inch-macbook-air-review-a-tiny-miracle");
            Assert.IsTrue(url.IsValid);
        }

        [Test]
        public void TestDomain()
        {
            var url = new Url("http://watchdogapp.com/folder1/page1.html");

            Assert.AreEqual("watchdogapp.com", url.Domain);
        }

        [Test]
        public void TestDomainOnNonStandardPort()
        {
            var url = new Url("http://watchdogapp.com:8080/folder1/page1.html");

            Assert.AreEqual("watchdogapp.com:8080", url.Domain);
        }

        [Test]
        public void TestDomainWithHttpProtocol()
        {
            var url = new Url("http://watchdogapp.com/folder1/page1.html");

            Assert.AreEqual("http://watchdogapp.com", url.DomainWithProtocol);
        }


        [Test]
        public void TestDomainWithHttpsProtocolOnNonStandardPort()
        {
            var url = new Url("https://watchdogapp.com:666/folder1/page1.html");

            Assert.AreEqual("https://watchdogapp.com:666", url.DomainWithProtocol);
        }

        [Test]
        public void TestDomainWithoutWwwPrefix()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.AreEqual("watchdogapp.com", url.DomainSansWww);
        }

        [Test]
        public void TestFullPage()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.AreEqual("/folder1/page1.html", url.FullPage);
        }

        [Test]
        public void TestFullPageWhenJustADomain()
        {
            var url = new Url("http://www.watchdogapp.com");

            Assert.AreEqual("Site Root", url.FullPage);
        }

        [Test]
        public void TestFullPageWhenJustADomainWithATrailingSlash()
        {
            var url = new Url("http://www.watchdogapp.com/");

            Assert.AreEqual("Site Root", url.FullPage);
        }

        [Test]
        public void TestPage()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.AreEqual("page1.html", url.Page);
        }

        [Test]
        public void TestPageWhenJustADomain()
        {
            var url = new Url("http://www.watchdogapp.com");

            Assert.AreEqual("Site Root", url.Page);
        }

        [Test]
        public void TestFullPageWithQueryString()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html?parameter=first");

            Assert.AreEqual("/folder1/page1.html?parameter=first", url.FullPageWithQueryString);
        }

        [Test]
        public void TestFullPageWithQueryStringWhenNoQuery()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.AreEqual("/folder1/page1.html", url.FullPageWithQueryString);
        }

        [Test]
        public void TestPathWithRootDomain()
        {
            var url = new Url("http://www.watchdogapp.com");

            Assert.AreEqual("/", url.Path);
        }

        [Test]
        public void TestPathWithOneFolderDeep()
        {
            var url = new Url("http://www.watchdogapp.com/folder/");

            Assert.AreEqual("/folder/", url.Path);
        }

        [Test]
        public void TestPathWithTwoFolderDeep()
        {
            var url = new Url("http://www.watchdogapp.com/folder/second/");

            Assert.AreEqual("/folder/second/", url.Path);
        }

        [Test]
        public void TestPathWithFilenameDeep()
        {
            var url = new Url("http://www.watchdogapp.com/folder/second/page.html");

            Assert.AreEqual("/folder/second/", url.Path);
        }

        [Test]
        public void TestToStringWithQueryAndFragmentNoQueryNoFragment()
        {
            var url = new Url("http://www.google.com");

            Assert.AreEqual("http://www.google.com/", url.ToStringWithQueryAndFragment());
        }

        [Test]
        public void TestToStringWithQueryAndFragmentNoQueryHasFragment()
        {
            var url = new Url("http://www.google.com") { Fragment = "5" };

            Assert.AreEqual("http://www.google.com/#5", url.ToStringWithQueryAndFragment());
        }

        [Test]
        public void TestToStringWithQueryAndFragmentHasQueryNoFragment()
        {
            var url = new Url("http://www.google.com").AddToQuery("page", 5);

            Assert.AreEqual("http://www.google.com/?page=5", url.ToStringWithQueryAndFragment());
        }

        [Test]
        public void TestToStringWithQueryAndFragmentHasQueryAndFragment()
        {
            var url = new Url("http://www.google.com") { Fragment = "5" }.AddToQuery("page", 5);

            Assert.AreEqual("http://www.google.com/?page=5#5", url.ToStringWithQueryAndFragment());
        }

        [Test]
        public void TestToStringWithQueryAndFragmentRemoveQuery()
        {
            var url = new Url("http://www.google.com/?page=5").RemoveFromQuery("page");

            Assert.AreEqual("http://www.google.com/", url.ToStringWithQueryAndFragment());
        }

        [Test]
        public void TestDomainSansSubDomains()
        {
            var url = new Url("http://www.news.bbc.co.uk/");

            Assert.AreEqual("bbc.co.uk", url.DomainSansSubDomain);
        }

        [Test]
        public void TestSingleDomainSansSubDomains()
        {
            var url = new Url("http://stackoverflow.com/");

            Assert.AreEqual("stackoverflow.com", url.DomainSansSubDomain);
        }

        [Test]
        public void TestLongDomainSansSubDomains()
        {
            var url = new Url("http://www.sales.stores.ebay.co.uk/");

            Assert.AreEqual("ebay.co.uk", url.DomainSansSubDomain);
        }

        [Test]
        public void TestMixedCaseDomainSansSubDomains()
        {
            var url = new Url("http://WWW.EBAY.CO.UK/");

            Assert.AreEqual("ebay.co.uk", url.DomainSansSubDomain);
        }

        [Test]
        public void TestNoDomainSansSubDomains()
        {
            var url = new Url("http:///search?id=50");

            Assert.AreEqual(string.Empty, url.DomainSansSubDomain);
        }

        [Test]
        public void TestDomainWithoutSubdomainWhenNoSubdomain()
        {
            var url = new Url("http://www.eed.eg/index.html");

            Assert.AreEqual("eed.eg", url.DomainSansSubDomain);
        }
    }
}