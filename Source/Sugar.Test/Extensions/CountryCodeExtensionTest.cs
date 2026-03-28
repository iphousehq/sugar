using System;
using NUnit.Framework;
using Sugar.Attributes;
using System.Reflection;

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
            Assert.That(CountryCode.AS.ToIso6381(), Is.EqualTo("ws"));
            Assert.That(CountryCode.SE.ToIso6381(), Is.EqualTo("se"));
        }

        [Test]
        public void TestAllAlpha3AttributesRoundtrip()
        {
            foreach (CountryCode code in Enum.GetValues(typeof(CountryCode)))
            {
                var attr = typeof(CountryCode).GetField(code.ToString())?.GetCustomAttribute<Alpha3Attribute>();
                if (attr == null) continue;

                var alpha3 = code.ToAlpha3();
                var roundtripped = alpha3.ToAlpha2();

                Assert.That(roundtripped, Is.EqualTo(code), $"Roundtrip failed for {code}: ToAlpha3()={alpha3}, ToAlpha2()={roundtripped}");
            }
        }
    }
}
