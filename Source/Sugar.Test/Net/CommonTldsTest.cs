using NUnit.Framework;

namespace Sugar.Net
{
    [TestFixture]
    public class CommonTldsTest
    {
        [Test]
        public void TestGetBestTldMatch()
        {
            var tld = CommonTlds.Instance.GetTld("bbc.co.uk");

            Assert.That(tld, Is.EqualTo("co.uk"));
        }

        [Test]
        public void TestGetBestTldMatchWhenMultipleMatches()
        {
            // Both '.bs' and '.com.bs' are valid.
            var tld = CommonTlds.Instance.GetTld("something.com.bs");

            Assert.That(tld, Is.EqualTo("com.bs"));
        }

        [Test]
        public void TestGetBestTldMatchWhenAmazonCanada()
        {
            var tld = CommonTlds.Instance.GetTld("amazon.ca");

            Assert.That(tld, Is.EqualTo("ca"));

            tld = CommonTlds.Instance.GetTld("amaz.on.ca");

            Assert.That(tld, Is.EqualTo("on.ca"));
        }

        [Test]
        public void TestGetBestTldMatchWhenNoPredefinedMatches()
        {
            var tld = CommonTlds.Instance.GetTld("zdssihsgifsd.sdiusfhisdfhs.sfisdfisdfsdif");

            Assert.That(tld, Is.EqualTo("sfisdfisdfsdif"));
        }
    }
}
