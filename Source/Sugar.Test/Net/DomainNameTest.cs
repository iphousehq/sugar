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

            Assert.AreEqual("domainname.com", sansSubDomain);
        }

        [Test]
        public void TestSubDomain()
        {
            var subDomain = new DomainName("www.domainname.com").SubDomain;

            Assert.AreEqual("www", subDomain);
        }
    }
}
