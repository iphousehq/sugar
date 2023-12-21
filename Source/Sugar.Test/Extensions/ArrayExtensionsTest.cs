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

            Assert.That(slice.Length, Is.EqualTo(2));
            Assert.That(slice[0], Is.EqualTo(1));
            Assert.That(slice[1], Is.EqualTo(2));
        }
    }
}
