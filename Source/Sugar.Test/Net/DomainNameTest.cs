using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class DomainNameTest
    {
        [Test]
        public void TestDomainSansSubDomain()
        {
            var sansSubDomain = new DomainName("www.domainname.com").DomainSansSubDomain;

            Assert.That(sansSubDomain, Is.EqualTo("domainname.com"));
        }

        [Test]
        public void TestSubDomain()
        {
            var subDomain = new DomainName("www.domainname.com").SubDomain;

            Assert.That(subDomain, Is.EqualTo("www"));
        }
    }
}
