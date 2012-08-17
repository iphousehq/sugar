using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class Int32ExtensionsTest
    {
        [Test]
        public void TestAsInt32()
        {
            Assert.AreEqual(100, "100".AsInt32());
        }

        [Test]
        public void TestOrdinalMinusOne()
        {
            var result = (-1).AddOrdinal();

            Assert.AreEqual("-1", result);
        }

        [Test]
        public void TestOrdinalZero()
        {
            var result = 0.AddOrdinal();

            Assert.AreEqual("0", result);
        }

        [Test]
        public void TestOrdinalOne()
        {
            var result = 1.AddOrdinal();

            Assert.AreEqual("1st", result);
        }

        [Test]
        public void TestOrdinalTwo()
        {
            var result = 2.AddOrdinal();

            Assert.AreEqual("2nd", result);
        }

        [Test]
        public void TestOrdinalThree()
        {
            var result = 3.AddOrdinal();

            Assert.AreEqual("3rd", result);
        }

        [Test]
        public void TestOrdinalFour()
        {
            var result = 4.AddOrdinal();

            Assert.AreEqual("4th", result);
        }

        [Test]
        public void TestOrdinalEleven()
        {
            var result = 11.AddOrdinal();

            Assert.AreEqual("11th", result);
        }

        [Test]
        public void TestOrdinalTwelve()
        {
            var result = 12.AddOrdinal();

            Assert.AreEqual("12th", result);
        }

        [Test]
        public void TestOrdinalThirteen()
        {
            var result = 13.AddOrdinal();

            Assert.AreEqual("13th", result);
        }

        [Test]
        public void TestOrdinalFourteen()
        {
            var result = 14.AddOrdinal();

            Assert.AreEqual("14th", result);
        }

        [Test]
        public void TestOrdinalTwentyOne()
        {
            var result = 21.AddOrdinal();

            Assert.AreEqual("21st", result);
        }

        [Test]
        public void TestOrdinalTwentyTwo()
        {
            var result = 22.AddOrdinal();

            Assert.AreEqual("22nd", result);
        }

        [Test]
        public void TestOrdinalTwentyThree()
        {
            var result = 23.AddOrdinal();

            Assert.AreEqual("23rd", result);
        }

        [Test]
        public void TestOrdinalTwentyFour()
        {
            var result = 24.AddOrdinal();

            Assert.AreEqual("24th", result);
        }
    }
}
