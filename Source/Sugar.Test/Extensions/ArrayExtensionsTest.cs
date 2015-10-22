using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class ArrayExtensionsTest
    {
        [Test]
        public void TestSliceArray()
        {
            var intArray = new[] { 0, 1, 2, 3, 4, 5 };

            var slice = intArray.Slice(1, 2);

            Assert.AreEqual(2, slice.Length);
            Assert.AreEqual(1, slice[0]);
            Assert.AreEqual(2, slice[1]);
        }
    }
}