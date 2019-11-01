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
                Assert.IsNotNull(symbol);

                var htmlSymbol = value.ToHtmlSymbol();
                Assert.IsNotNull(htmlSymbol);
            }
        }

        [Test]
        public void TestToCurrencyCodeFromSymbol()
        {
            var result = "¥".ToCurrencyCode();

            Assert.AreEqual(CurrencyCode.JPY, result);
        }

        [Test]
        public void TestToCurrencyCodeFromIso()
        {
            var result = "GBP".ToCurrencyCode();

            Assert.AreEqual(CurrencyCode.GBP, result);
        }

        [Test]
        public void TestToCurrencyCodeFromLowerCaseValue()
        {
            var result = "eur".ToCurrencyCode();

            Assert.AreEqual(CurrencyCode.EUR, result);
        }

        [Test]
        public void TestToCurrencyCodeFromUnknown()
        {
            Assert.Throws<ApplicationException>(() => "ghgtgtrgtrg".ToCurrencyCode());
        }

        [Test]
        public void TestToCountryCodetoCurrency()
        {
            Assert.AreEqual(CurrencyCode.GBP, CountryCode.GB.ToCurrencyCode());
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

            Assert.False(result.HasValue);
        }

        [Test]
        public void TestFindCurrencyCodeWhenSingleCodeExists()
        {
            var result = "$3,500".FindCurrencyCode();

            Assert.True(result.HasValue);
            Assert.AreEqual(CurrencyCode.USD, result.Value);
        }

        [Test]
        public void TestFindCurrencyCodeWhenMultipleCodesExists()
        {
            var result = "There is a £ symbol here before $3,500".FindCurrencyCode();

            Assert.True(result.HasValue);
            Assert.AreEqual(CurrencyCode.GBP, result.Value);
        }

        [Test]
        public void TestCountryNameToCountryCode()
        {
            var ukInCa = CountryCodeExtensions.CountryNameToCountryCode(CountryCode.CA, "United Kingdom");
            var brInBr = CountryCodeExtensions.CountryNameToCountryCode(CountryCode.BR, "Brasil");

            Assert.IsNotNull(ukInCa);
            Assert.AreEqual(CountryCode.GB, ukInCa);

            Assert.IsNotNull(brInBr);
            Assert.AreEqual(CountryCode.BR, brInBr);
        }
    }
}
