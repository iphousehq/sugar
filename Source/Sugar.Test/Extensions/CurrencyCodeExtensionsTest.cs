using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Sugar.Attributes;

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
        public void TestToCountryCodeToCurrency()
        {
            Assert.That(CountryCode.GB.ToCurrencyCode(), Is.EqualTo(CurrencyCode.GBP));
        }

        [Test]
        public void TestToCountryCodeToCurrencyForAfghanistan()
        {
            Assert.That(CountryCode.AF.ToCurrencyCode(), Is.EqualTo(CurrencyCode.AFN));
        }

        [Test]
        public void TestToCountryCodeToCurrencyWhenUnknownCurrency()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => CountryCode.Unknown.ToCurrencyCode());
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
            Assert.That(result, Is.EqualTo(CurrencyCode.USD));
        }

        [Test]
        public void TestFindCurrencyCodeWhenMultipleCodesExists()
        {
            var result = "There is a £ symbol here before $3,500".FindCurrencyCode();

            Assert.That(result.HasValue, Is.True);
            Assert.That(result, Is.EqualTo(CurrencyCode.GBP));
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

        /// <summary>
        /// Every CurrencyCode value must have [Description], [Symbol], and [HtmlSymbol].
        /// If this test fails, add the missing attributes to the new enum value.
        /// </summary>
        [Test]
        public void TestAllCurrencyCodesHaveRequiredAttributes()
        {
            var missing = new List<string>();

            foreach (CurrencyCode code in Enum.GetValues(typeof(CurrencyCode)))
            {
                var field = typeof(CurrencyCode).GetField(code.ToString());
                if (field.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>() == null)
                    missing.Add($"{code}: missing [Description]");
                if (field.GetCustomAttribute<SymbolAttribute>() == null)
                    missing.Add($"{code}: missing [Symbol]");
                if (field.GetCustomAttribute<HtmlSymbolAttribute>() == null)
                    missing.Add($"{code}: missing [HtmlSymbol]");
            }

            Assert.That(missing, Is.Empty, "CurrencyCode values with missing attributes:\n" + string.Join("\n", missing));
        }

        [Test]
        public void TestAllCurrencyCodesCanBeConvertedToCountry()
        {
            var missing = new List<string>();

            foreach (CurrencyCode code in Enum.GetValues(typeof(CurrencyCode)))
            {
                try
                {
                    code.ToCountryCode();
                }
                catch (ApplicationException)
                {
                    if (code is not (CurrencyCode.VEF or CurrencyCode.VES or CurrencyCode.VEF_BLKMKT))
                    {
                        missing.Add(code.ToString());
                    }
                }
            }

            Assert.That(missing, Is.Empty, "CurrencyCode values that cannot be converted:\n" + string.Join("\n", missing));
        }

        [Test]
        public void TestCurrencyToCountryCodeRoundtrip()
        {
            // For every currency that has a primary country, converting back to currency must give the same code.
            // This guards the BuildCountryLookup heuristic for multi-country currencies like EUR.
            foreach (CurrencyCode currency in Enum.GetValues(typeof(CurrencyCode)))
            {
                CountryCode country;

                try
                {
                    country = currency.ToCountryCode();
                }
                catch (ApplicationException)
                {
                    continue; // Currency has no primary country mapping — expected for some
                }

                var roundtripped = country.ToCurrencyCode();
                Assert.That(roundtripped, Is.EqualTo(currency), $"Roundtrip failed: {currency} -> {country} -> {roundtripped}");
            }
        }
    }
}
