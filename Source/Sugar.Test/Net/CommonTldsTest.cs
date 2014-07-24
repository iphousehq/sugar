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

            Assert.AreEqual("co.uk", tld);
        }

        [Test]
        public void TestGetBestTldMatchWhenMultipleMatches()
        {
            // Both '.bs' and '.com.bs' are valid.
            var tld = CommonTlds.Instance.GetTld("something.com.bs");

            Assert.AreEqual("com.bs", tld);
        }

        [Test]
        public void TestGetBestTldMatchWhenAmazonCanada()
        {
            var tld = CommonTlds.Instance.GetTld("amazon.ca");

            Assert.AreEqual("ca", tld);

            tld = CommonTlds.Instance.GetTld("amaz.on.ca");

            Assert.AreEqual("on.ca", tld);
        }

        [Test]
        public void TestGetBestTldMatchWhenNoPredefinedMatches()
        {
            var tld = CommonTlds.Instance.GetTld("zdssihsgifsd.sdiusfhisdfhs.sfisdfisdfsdif");

            Assert.AreEqual("sfisdfisdfsdif", tld);
        }
    }
}
