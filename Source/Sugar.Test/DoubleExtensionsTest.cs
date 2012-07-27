using System;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class DoubleExtensionsTest
    {
        [Test]
        public void TestFromUnixTimestamp()
        {
            var time = 1293840000.0d.FromUnixTimestamp();

            Assert.AreEqual(new DateTime(2011, 1, 1), time);
        }

        [Test]
        public void TestFormatWithoutText()
        {
            var result = 156700.00.Format();

            Assert.AreEqual("156,700", result);
        }

        [Test]
        public void TestFormatLessThanAThousandWithDecimalPlace()
        {
            var result = 500.6789.Format(true);

            Assert.AreEqual("500.68", result);
        }

        [Test]
        public void TestFormatLessThanAThousand()
        {
            var result = 500.00.Format(true);

            Assert.AreEqual("500", result);
        }

        [Test]
        public void TestFormatNegativeNumber()
        {
            var result = (-500.00).Format(true);

            Assert.AreEqual("-500", result);
        }

        [Test]
        public void TestFormatAThousand()
        {
            var result = 1500.00.Format(true);

            Assert.AreEqual("1,500", result);
        }

        [Test]
        public void TestFormatAThousandWithDecimalPlaces()
        {
            var result = 1555.55.Format(true);

            Assert.AreEqual("1,555.55", result);
        }

        [Test]
        public void TestFormatAHundredThousand()
        {
            var result = 150000.00.Format(true);

            Assert.AreEqual("150 thousand", result);
        }

        [Test]
        public void TestFormatAHundredThousandWithDecimalPlaces()
        {
            var result = 155555.55.Format(true);

            Assert.AreEqual("156 thousand", result);
        }
        [Test]
        public void TestFormatAMillion()
        {
            var result = 1000000.00.Format(true);

            Assert.AreEqual("1 million", result);
        }

        [Test]
        public void TestFormatAMillionWithDecimalPlaces()
        {
            var result = 1555555.55.Format(true);

            Assert.AreEqual("1.6 million", result);
        }

        [Test]
        public void TestFormatABillion()
        {
            var result = 1000000000.00.Format(true);

            Assert.AreEqual("1 billion", result);
        }

        [Test]
        public void TestFormatABillionWithDecimalPlaces()
        {
            var result = 1555555555.55.Format(true);

            Assert.AreEqual("1.6 billion", result);
        }
    }
}
