using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class IntExtensionsTest
    {
        [Test]
        public void TestOrdinalMinusOne()
        {
            var result = (-1).AddOrdinal();

            Assert.That(result, Is.EqualTo("-1"));
        }

        [Test]
        public void TestOrdinalZero()
        {
            var result = 0.AddOrdinal();

            Assert.That(result, Is.EqualTo("0"));
        }

        [Test]
        public void TestOrdinalOne()
        {
            var result = 1.AddOrdinal();

            Assert.That(result, Is.EqualTo("1st"));
        }

        [Test]
        public void TestOrdinalTwo()
        {
            var result = 2.AddOrdinal();

            Assert.That(result, Is.EqualTo("2nd"));
        }

        [Test]
        public void TestOrdinalThree()
        {
            var result = 3.AddOrdinal();

            Assert.That(result, Is.EqualTo("3rd"));
        }

        [Test]
        public void TestOrdinalFour()
        {
            var result = 4.AddOrdinal();

            Assert.That(result, Is.EqualTo("4th"));
        }

        [Test]
        public void TestOrdinalEleven()
        {
            var result = 11.AddOrdinal();

            Assert.That(result, Is.EqualTo("11th"));
        }

        [Test]
        public void TestOrdinalTwelve()
        {
            var result = 12.AddOrdinal();

            Assert.That(result, Is.EqualTo("12th"));
        }

        [Test]
        public void TestOrdinalThirteen()
        {
            var result = 13.AddOrdinal();

            Assert.That(result, Is.EqualTo("13th"));
        }

        [Test]
        public void TestOrdinalFourteen()
        {
            var result = 14.AddOrdinal();

            Assert.That(result, Is.EqualTo("14th"));
        }

        [Test]
        public void TestOrdinalTwentyOne()
        {
            var result = 21.AddOrdinal();

            Assert.That(result, Is.EqualTo("21st"));
        }

        [Test]
        public void TestOrdinalTwentyTwo()
        {
            var result = 22.AddOrdinal();

            Assert.That(result, Is.EqualTo("22nd"));
        }

        [Test]
        public void TestOrdinalTwentyThree()
        {
            var result = 23.AddOrdinal();

            Assert.That(result, Is.EqualTo("23rd"));
        }

        [Test]
        public void TestOrdinalTwentyFour()
        {
            var result = 24.AddOrdinal();

            Assert.That(result, Is.EqualTo("24th"));
        }

        [Test]
        public void TestPercentOf()
        {
            var result = 25.PercentOf(1000);

            Assert.That(result, Is.EqualTo(2.5));
        }       
    }
}
