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

            Assert.AreEqual(tld, "co.uk");
        }

        [Test]
        public void TestGetBestTldMatchWhenMultipleMatches()
        {
            // Both '.bs' and '.com.bs' are valid.
            var tld = CommonTlds.Instance.GetTld("com.bs");

            Assert.AreEqual(tld, "com.bs");
        }

        [Test]
        public void TestGetBestTldMatchWhenNoPredefinedMatches()
        {
            // Both '.bs' and '.com.bs' are valid.
            var tld = CommonTlds.Instance.GetTld("zdssihsgifsd.sdiusfhisdfhs.sfisdfisdfsdif");

            Assert.AreEqual(tld, "sfisdfisdfsdif");
        }
    }
}
