using System;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class CurrencyCodeExtensionsTest
    {
        [Test]
        public void TestCurrenciesToSymbol()
        {
            var values = Enum.GetValues(typeof (CurrencyCode));
            foreach (CurrencyCode value in values)
            {
                var symbol = value.ToSymbol();
                Assert.That(symbol, Is.Not.Null);

                var htmlSymbol = value.ToHtmlSymbol();
                Assert.That(htmlSymbol, Is.Not.Null);
            }
        }

        [Test]
        public void TestToCurrencyCodeFromSymbol()
        {
            var result = "¥".ToCurrencyCode();

            Assert.That(result, Is.EqualTo(CurrencyCode.JPY));
        }

        [Test]
        public void TestToCurrencyCodeFromIso()
        {
            var result = "GBP".ToCurrencyCode();

            Assert.That(result, Is.EqualTo(CurrencyCode.GBP));
        }

        [Test]
        public void TestToCurrencyCodeFromLowerCaseValue()
        {
            var result = "eur".ToCurrencyCode();

            Assert.That(result, Is.EqualTo(CurrencyCode.EUR));
        }

        [Test]
        public void TestToCurrencyCodeFromUnknown()
        {
            Assert.Throws<ApplicationException>(() => "ghgtgtrgtrg".ToCurrencyCode());
        }

        [Test]
        public void TestToCountryCodetoCurrency()
        {
            Assert.That(CountryCode.GB.ToCurrencyCode(), Is.EqualTo(CurrencyCode.GBP));
        }

        [Test]
        public void TestToCountryCodetoCurrencyWhenUnknownCurrency()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CountryCode.AF.ToCurrencyCode());
        }

        [Test]
        public void TestFindCurrencyCodeWhenNoCodeExists()
        {
            var result = "3,500".FindCurrencyCode();

            Assert.That(result.HasValue, Is.False);
        }

        [Test]
        public void TestFindCurrencyCodeWhenSingleCodeExists()
        {
            var result = "$3,500".FindCurrencyCode();

            Assert.That(result.HasValue, Is.True);
            Assert.That(result.Value, Is.EqualTo(CurrencyCode.USD));
        }

        [Test]
        public void TestFindCurrencyCodeWhenMultipleCodesExists()
        {
            var result = "There is a £ symbol here before $3,500".FindCurrencyCode();

            Assert.That(result.HasValue, Is.True);
            Assert.That(result.Value, Is.EqualTo(CurrencyCode.GBP));
        }

        [Test]
        public void TestCurrencyCodeToCountryCode()
        {
            Assert.That(CurrencyCode.GBP.ToCountryCode(), Is.EqualTo(CountryCode.GB));
        }

        [Test]
        public void TestCurrencyToCountryCodeCodeForUnknownCountry()
        {
            Assert.Throws<ApplicationException>(() => ((CurrencyCode) 100000).ToCountryCode());
        }
    }
}
