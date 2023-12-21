using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class CountryCodeExtensionTest
    {
        [Test]
        public void TestCountryCodeAlpha2ToAlpha3()
        {
            Assert.That(CountryCode.GB.ToAlpha3(), Is.EqualTo(CountryCode3.GBR));
        }

        [Test]
        public void TestCountryCodeAlpha3ToAlpha2()
        {
            Assert.That(CountryCode3.GBR.ToAlpha2(), Is.EqualTo(CountryCode.GB));
        }

        [Test]
        public void TestCountryCodeToGoogleSearchCountry()
        {
            Assert.That(CountryCode.GB.ToIso6381(), Is.EqualTo("uk"));
            Assert.That(CountryCode.US.ToIso6381(), Is.EqualTo(""));
            Assert.That(CountryCode.SE.ToIso6381(), Is.EqualTo("se"));
        }
    }
}
