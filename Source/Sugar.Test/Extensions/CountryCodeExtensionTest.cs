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

        // Application-level sentinel values that are not real ISO 3166-1 country codes
        // and intentionally omit standard attributes like [Description] and [LanguageTag].
        private static readonly HashSet<CountryCode> AttributeExceptions = new HashSet<CountryCode>
        {
            CountryCode.CustomCode, // Application-level sentinel; not a real country
            CountryCode.Unknown,    // Application-level sentinel; not a real country
            CountryCode.Global,     // Application-level sentinel; not a real country
            CountryCode.AA,         // Reserved by ISO 3166; has no language tag
        };

        /// <summary>
        /// Every CountryCode value must have [Description] and [LanguageTag].
        /// If this test fails, add the missing attributes to the new enum value.
        /// </summary>
        [Test]
        public void TestAllCountryCodesHaveRequiredAttributes()
        {
            var missing = new List<string>();

            foreach (CountryCode code in Enum.GetValues(typeof(CountryCode)))
            {
                if (AttributeExceptions.Contains(code)) continue;

                var field = typeof(CountryCode).GetField(code.ToString());

                if (field.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>() == null)
                    missing.Add($"{code}: missing [Description]");

                if (field.GetCustomAttribute<LanguageTagAttribute>() == null)
                    missing.Add($"{code}: missing [LanguageTag]");
            }

            Assert.That(missing, Is.Empty, "CountryCode values with missing attributes:\n" + string.Join("\n", missing));
        }

        /// <summary>
        /// Every CountryCode value must have [Alpha3], unless it is listed in <see cref="Alpha3Exceptions"/>.
        /// If this test fails for a new standard country code, add [Alpha3(CountryCode3.XXX)] to the enum value.
        /// If it is a non-standard pseudo-code with no ISO 3166-1 alpha-3, add it to <see cref="Alpha3Exceptions"/> instead.
        /// </summary>
        [Test]
        public void TestAllCountryCodesHaveAlpha3OrAreExplicitlyExcluded()
        {
            var missing = Enum.GetValues(typeof(CountryCode))
                .Cast<CountryCode>()
                .Where(c => typeof(CountryCode).GetField(c.ToString()).GetCustomAttribute<Alpha3Attribute>() == null)
                .Where(c => !Alpha3Exceptions.Contains(c))
                .Select(c => c.ToString())
                .ToList();

            Assert.That(missing, Is.Empty,
                "CountryCode values missing [Alpha3] that are not in Alpha3Exceptions:\n" + string.Join("\n", missing) +
                "\nEither add [Alpha3(CountryCode3.XXX)] to the enum value, or add it to Alpha3Exceptions if it has no ISO 3166-1 alpha-3.");
        }

        // CountryCode values that intentionally have no [Alpha3] mapping.
        // Add new entries here only when no ISO 3166-1 alpha-3 exists for the code.
        private static readonly HashSet<CountryCode> Alpha3Exceptions = new HashSet<CountryCode>
        {
            CountryCode.EU,         // Eurozone pseudo-code; not a sovereign state
            CountryCode.AA,         // Reserved by ISO 3166
            CountryCode.FY,         // Non-standard
            CountryCode.CustomCode, // Application-level sentinel; not a real country
            CountryCode.Unknown,    // Application-level sentinel; not a real country
            CountryCode.Global,     // Application-level sentinel; not a real country
            CountryCode.GG,   // Guernsey — not in original alpha-3 mapping
            CountryCode.IM,   // Isle of Man — not in original alpha-3 mapping
            CountryCode.JE,   // Jersey — not in original alpha-3 mapping
            CountryCode.ME,   // Montenegro — not in original alpha-3 mapping
            CountryCode.BL,   // Saint Barthélemy — not in original alpha-3 mapping
            CountryCode.MF,   // Saint Martin — not in original alpha-3 mapping
            CountryCode.RS,   // Serbia — not in original alpha-3 mapping
            CountryCode.SS,   // South Sudan — not in original alpha-3 mapping
            CountryCode.CW,   // Curaçao — not in original alpha-3 mapping
            CountryCode.SX,   // Sint Maarten — not in original alpha-3 mapping
        };
    }
}
