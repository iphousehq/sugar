using System;
using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class UrlTest
    {
        [Test]
        public void TestNullUrl()
        {
            var url = new Url((string) null);

            Assert.That(url.IsValid, Is.False);
            Assert.That(url.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestEmptyUrl()
        {
            var url = new Url(string.Empty);

            Assert.That(url.IsValid, Is.False);
            Assert.That(url.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestInvalidUrl()
        {
            var url = new Url("i'm invalid");

            Assert.That(url.IsValid, Is.False);
            Assert.That(url.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestValidUrl()
        {
            var url = new Url("http://watchdogapp.com/folder1/page1.html");

            Assert.That(url.IsValid, Is.True);
            Assert.That(url.ToString(), Is.EqualTo("http://watchdogapp.com/folder1/page1.html"));

            url = new Url("http://gizmodo.com/5678421/11+inch-macbook-air-review-a-tiny-miracle");
            Assert.That(url.IsValid, Is.True);
        }

        [Test]
        public void TestConstructUrlFromUri()
        {
            var uri = new Uri("http://watchdogapp.com/folder1/page1.html");
            
            var url = new Url(uri);

            Assert.That(url.IsValid, Is.True);
            Assert.That(url.ToString(), Is.EqualTo("http://watchdogapp.com/folder1/page1.html"));
        }

        [Test]
        public void TestDomain()
        {
            var url = new Url("http://watchdogapp.com/folder1/page1.html");

            Assert.That(url.Domain, Is.EqualTo("watchdogapp.com"));
        }

        [Test]
        public void TestDomainOnNonStandardPort()
        {
            var url = new Url("http://watchdogapp.com:8080/folder1/page1.html");

            Assert.That(url.Domain, Is.EqualTo("watchdogapp.com:8080"));
        }

        [Test]
        public void TestDomainWhenSubdomainIsSpecified()
        {
            var url = new Url("http://sub.watchdogapp.com/folder1/page1.html");

            Assert.That(url.Domain, Is.EqualTo("sub.watchdogapp.com"));
        }

        [Test]
        public void TestDomainWithHttpProtocol()
        {
            var url = new Url("http://watchdogapp.com/folder1/page1.html");

            Assert.That(url.DomainWithProtocol, Is.EqualTo("http://watchdogapp.com"));
        }


        [Test]
        public void TestDomainWithHttpsProtocolOnNonStandardPort()
        {
            var url = new Url("https://watchdogapp.com:666/folder1/page1.html");

            Assert.That(url.DomainWithProtocol, Is.EqualTo("https://watchdogapp.com:666"));
        }

        [Test]
        public void TestDomainWithoutWwwPrefix()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.That(url.DomainSansWww, Is.EqualTo("watchdogapp.com"));
        }

        [Test]
        public void TestDomainWithoutWwwPrefixWhenSubdomainPresent()
        {
            var url = new Url("http://sub.watchdogapp.com/folder1/page1.html");

            Assert.That(url.DomainSansWww, Is.EqualTo("sub.watchdogapp.com"));
        }

        [Test]
        public void TestFullPage()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.That(url.FullPage, Is.EqualTo("/folder1/page1.html"));
        }

        [Test]
        public void TestFullPageWhenJustADomain()
        {
            var url = new Url("http://www.watchdogapp.com");

            Assert.That(url.FullPage, Is.EqualTo("Site Root"));
        }

        [Test]
        public void TestFullPageWhenJustADomainWithATrailingSlash()
        {
            var url = new Url("http://www.watchdogapp.com/");

            Assert.That(url.FullPage, Is.EqualTo("Site Root"));
        }

        [Test]
        public void TestPage()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.That(url.Page, Is.EqualTo("page1.html"));
        }

        [Test]
        public void TestPageWhenJustADomain()
        {
            var url = new Url("http://www.watchdogapp.com");

            Assert.That(url.Page, Is.EqualTo("Site Root"));
        }

        [Test]
        public void TestFullPageWithQueryString()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html?parameter=first");

            Assert.That(url.FullPageWithQueryString, Is.EqualTo("/folder1/page1.html?parameter=first"));
        }

        [Test]
        public void TestFullPageWithQueryStringWhenNoQuery()
        {
            var url = new Url("http://www.watchdogapp.com/folder1/page1.html");

            Assert.That(url.FullPageWithQueryString, Is.EqualTo("/folder1/page1.html"));
        }

        [Test]
        public void TestPathWithRootDomain()
        {
            var url = new Url("http://www.watchdogapp.com");

            Assert.That(url.Path, Is.EqualTo("/"));
        }

        [Test]
        public void TestPathWithOneFolderDeep()
        {
            var url = new Url("http://www.watchdogapp.com/folder/");

            Assert.That(url.Path, Is.EqualTo("/folder/"));
        }

        [Test]
        public void TestPathWithTwoFolderDeep()
        {
            var url = new Url("http://www.watchdogapp.com/folder/second/");

            Assert.That(url.Path, Is.EqualTo("/folder/second/"));
        }

        [Test]
        public void TestPathWithFilenameDeep()
        {
            var url = new Url("http://www.watchdogapp.com/folder/second/page.html");

            Assert.That(url.Path, Is.EqualTo("/folder/second/"));
        }

        [Test]
        public void TestToStringWithQueryAndFragmentNoQueryNoFragment()
        {
            var url = new Url("http://www.google.com");

            Assert.That(url.ToStringWithQueryAndFragment(), Is.EqualTo("http://www.google.com/"));
        }

        [Test]
        public void TestToStringWithQueryAndFragmentNoQueryHasFragment()
        {
            var url = new Url("http://www.google.com") { Fragment = "5" };

            Assert.That(url.ToStringWithQueryAndFragment(), Is.EqualTo("http://www.google.com/#5"));
        }

        [Test]
        public void TestToStringWithQueryAndFragmentHasQueryNoFragment()
        {
            var url = new Url("http://www.google.com").AddToQuery("page", 5);

            Assert.That(url.ToStringWithQueryAndFragment(), Is.EqualTo("http://www.google.com/?page=5"));
        }

        [Test]
        public void TestToStringWithQueryAndFragmentHasQueryAndFragment()
        {
            var url = new Url("http://www.google.com") { Fragment = "5" }.AddToQuery("page", 5);

            Assert.That(url.ToStringWithQueryAndFragment(), Is.EqualTo("http://www.google.com/?page=5#5"));
        }

        [Test]
        public void TestToStringWithQueryAndFragmentRemoveQuery()
        {
            var url = new Url("http://www.google.com/?page=5").RemoveFromQuery("page");

            Assert.That(url.ToStringWithQueryAndFragment(), Is.EqualTo("http://www.google.com/"));
        }

        [Test]
        public void TestDomainSansSubDomains()
        {
            var url = new Url("http://www.news.bbc.co.uk/");

            Assert.That(url.DomainSansSubDomain, Is.EqualTo("bbc.co.uk"));
        }

        [Test]
        public void TestSingleDomainSansSubDomains()
        {
            var url = new Url("http://stackoverflow.com/");

            Assert.That(url.DomainSansSubDomain, Is.EqualTo("stackoverflow.com"));
        }

        [Test]
        public void TestLongDomainSansSubDomains()
        {
            var url = new Url("http://www.sales.stores.ebay.co.uk/");

            Assert.That(url.DomainSansSubDomain, Is.EqualTo("ebay.co.uk"));
        }

        [Test]
        public void TestMixedCaseDomainSansSubDomains()
        {
            var url = new Url("http://WWW.EBAY.CO.UK/");

            Assert.That(url.DomainSansSubDomain, Is.EqualTo("ebay.co.uk"));
        }

        [Test]
        public void TestNoDomainSansSubDomains()
        {
            var url = new Url("http:///search?id=50");

            Assert.That(url.DomainSansSubDomain, Is.EqualTo(string.Empty));
        }

        [Test]
        public void TestDomainWithoutSubdomainWhenNoSubdomain()
        {
            var url = new Url("http://www.eed.eg/index.html");

            Assert.That(url.DomainSansSubDomain, Is.EqualTo("eed.eg"));
        }

        [Test]
        public void TestGetTldWhenTldPartOfSubdomain()
        {
            var url = new Url("http://company.watchdogapp.org");

            Assert.That(url.Tld, Is.EqualTo("org"));
        }

        [Test]
        public void TestSubdomianWhenTldPartofSubdomain()
        {
            var url = new Url("http://company.watchdogapp.com");

            Assert.That(url.SubDomain, Is.EqualTo("company"));
        }
    }
}
