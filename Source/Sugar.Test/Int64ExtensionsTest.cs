using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class Int64ExtensionsTest
    {
        [Test]
        public void TestAsInt64()
        {
            Assert.AreEqual(1000000000000000, "1000000000000000".AsInt64());
        }

        [Test]
        public void TestAsInt64WhenEmptyString()
        {
            Assert.AreEqual(0, "".AsInt64());
        }

        [Test]
        public void TestAsInt64WhenWhiteSpaceString()
        {
            Assert.AreEqual(0, " ".AsInt64());
        }
    }
}
