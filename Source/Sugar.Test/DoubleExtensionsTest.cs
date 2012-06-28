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
        public void TestFormatLessThanAThousand()
        {
            var result = 500.00.Format();

            Assert.AreEqual("500", result);
        }

        [Test]
        public void TestFormatNegativeNumber()
        {
            var result = (-500.00).Format();

            Assert.AreEqual("-500", result);
        }

        [Test]
        public void TestFormatAThousand()
        {
            var result = 1500.00.Format();

            Assert.AreEqual("1.5 thousand", result);
        }

        [Test]
        public void TestFormatAMillion()
        {
            var result = 1500000.00.Format();

            Assert.AreEqual("1.5 million", result);
        }

        [Test]
        public void TestFormatABillion()
        {
            var result = 1500000000.00.Format();

            Assert.AreEqual("1.5 billion", result);
        }
    }
}
