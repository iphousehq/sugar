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

            Assert.AreEqual(new DateTime(2011, 1, 1, 0, 0, 0), time.ToUniversalTime());
        }

        [Test]
        public void TestHumaniseWithoutText()
        {
            var result = 156700.00.Humanise();

            Assert.AreEqual("156,700", result);
        }

        [Test]
        public void TestHumaniseLessThanAThousandWithDecimalPlace()
        {
            var result = 500.6789.Humanise(true);

            Assert.AreEqual("500.68", result);
        }

        [Test]
        public void TestHumaniseLessThanAThousand()
        {
            var result = 500.00.Humanise(true);

            Assert.AreEqual("500", result);
        }

        [Test]
        public void TestHumaniseNegativeNumber()
        {
            var result = (-500.00).Humanise(true);

            Assert.AreEqual("-500", result);
        }

        [Test]
        public void TestHumaniseAThousand()
        {
            var result = 1500.00.Humanise(true);

            Assert.AreEqual("1,500", result);
        }

        [Test]
        public void TestHumaniseAThousandWithDecimalPlaces()
        {
            var result = 1555.55.Humanise(true);

            Assert.AreEqual("1,555.55", result);
        }

        [Test]
        public void TestHumaniseAHundredThousand()
        {
            var result = 150000.00.Humanise(true);

            Assert.AreEqual("150 thousand", result);
        }

        [Test]
        public void TestHumaniseAHundredThousandWithDecimalPlaces()
        {
            var result = 155555.55.Humanise(true);

            Assert.AreEqual("156 thousand", result);
        }
        [Test]
        public void TestHumaniseAMillion()
        {
            var result = 1000000.00.Humanise(true);

            Assert.AreEqual("1 million", result);
        }

        [Test]
        public void TestHumaniseAMillionWithDecimalPlaces()
        {
            var result = 1555555.55.Humanise(true);

            Assert.AreEqual("1.6 million", result);
        }

        [Test]
        public void TestHumaniseABillion()
        {
            var result = 1000000000.00.Humanise(true);

            Assert.AreEqual("1 billion", result);
        }

        [Test]
        public void TestHumaniseABillionWithDecimalPlaces()
        {
            var result = 1555555555.55.Humanise(true);

            Assert.AreEqual("1.6 billion", result);
        }
    }
}
