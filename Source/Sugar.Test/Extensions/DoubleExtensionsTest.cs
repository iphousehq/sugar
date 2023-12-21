using System;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class DoubleExtensionsTest
    {
        [Test]
        public void TestFromUnixTimestamp()
        {
            var time = 1293840000.0d.FromUnixTimestamp();

            Assert.That(time.ToUniversalTime(), Is.EqualTo(new DateTime(2011, 1, 1, 0, 0, 0)));
        }

        [Test]
        public void TestHumaniseWithoutText()
        {
            var result = 156700.00.Humanise();

            Assert.That(result, Is.EqualTo("156,700"));
        }

        [Test]
        public void TestHumaniseLessThanAThousandWithDecimalPlace()
        {
            var result = 500.6789.Humanise(true);

            Assert.That(result, Is.EqualTo("500.68"));
        }

        [Test]
        public void TestHumaniseLessThanAThousand()
        {
            var result = 500.00.Humanise(true);

            Assert.That(result, Is.EqualTo("500"));
        }

        [Test]
        public void TestHumaniseNegativeNumber()
        {
            var result = (-500.00).Humanise(true);

            Assert.That(result, Is.EqualTo("-500"));
        }

        [Test]
        public void TestHumaniseAThousand()
        {
            var result = 1500.00.Humanise(true);

            Assert.That(result, Is.EqualTo("1,500"));
        }

        [Test]
        public void TestHumaniseAThousandWithDecimalPlaces()
        {
            var result = 1555.55.Humanise(true);

            Assert.That(result, Is.EqualTo("1,555.55"));
        }

        [Test]
        public void TestHumaniseAHundredThousand()
        {
            var result = 150000.00.Humanise(true);

            Assert.That(result, Is.EqualTo("150 thousand"));
        }

        [Test]
        public void TestHumaniseAHundredThousandWithDecimalPlaces()
        {
            var result = 155555.55.Humanise(true);

            Assert.That(result, Is.EqualTo("156 thousand"));
        }
        [Test]
        public void TestHumaniseAMillion()
        {
            var result = 1000000.00.Humanise(true);

            Assert.That(result, Is.EqualTo("1 million"));
        }

        [Test]
        public void TestHumaniseAMillionWithDecimalPlaces()
        {
            var result = 1555555.55.Humanise(true);

            Assert.That(result, Is.EqualTo("1.6 million"));
        }

        [Test]
        public void TestHumaniseABillion()
        {
            var result = 1000000000.00.Humanise(true);

            Assert.That(result, Is.EqualTo("1 billion"));
        }

        [Test]
        public void TestHumaniseABillionWithDecimalPlaces()
        {
            var result = 1555555555.55.Humanise(true);

            Assert.That(result, Is.EqualTo("1.6 billion"));
        }
    }
}
