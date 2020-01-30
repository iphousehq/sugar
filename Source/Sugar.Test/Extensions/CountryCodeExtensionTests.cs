using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class CountryCodeExtensionTests
    {
        [Test]
        public void TestCountryCodeAlpha2ToAlpha3()
        {
            Assert.AreEqual(CountryCode3.GBR, CountryCode.GB.ToAlpha3());
        }

        [Test]
        public void TestCountryCodeAlpha3ToAlpha2()
        {
            Assert.AreEqual(CountryCode.GB, CountryCode3.GBR.ToAlpha2());
        }

        [Test]
        public void TestCountryCodeToGoogleSearchCountry()
        {
            Assert.AreEqual("uk", CountryCode.GB.ToGoogleSearchCountry());
            Assert.AreEqual("",CountryCode.US.ToGoogleSearchCountry());
            Assert.AreEqual("se",CountryCode.SE.ToGoogleSearchCountry());
        }
    }
}