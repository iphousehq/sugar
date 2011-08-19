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
    }
}
