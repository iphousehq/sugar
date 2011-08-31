using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void TestFromOneFieldString()
        {
            var results = "One".FromCsv();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("One", results[0]);
        }

        [Test]
        public void TestFromTwoFieldString()
        {
            var results = "One,Two".FromCsv();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("One", results[0]);
            Assert.AreEqual("Two", results[1]);
        }

        [Test]
        public void TestFromThreeFieldString()
        {
            var results = "One,Two,Three".FromCsv();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("One", results[0]);
            Assert.AreEqual("Two", results[1]);
            Assert.AreEqual("Three", results[2]);
        }

        [Test]
        public void TestFromQuotedString()
        {
            var results = @"One,""Two,Three,Four"",Three".FromCsv();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("One", results[0]);
            Assert.AreEqual("Two,Three,Four", results[1]);
            Assert.AreEqual("Three", results[2]);
        }

        [Test]
        public void TestFromCsvListOfInts()
        {
            var results = "1,2,3".FromCsv<int>();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1, results[0]);
            Assert.AreEqual(2, results[1]);
            Assert.AreEqual(3, results[2]);
        }
    }
}
