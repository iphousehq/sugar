using System.Collections.Generic;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void TestToCsvFromNull()
        {
            List<int> list = null;

            var csv = list.ToCsv();

            Assert.IsEmpty(csv);
        }

        [Test]
        public void TestMethodName()
        {
            var list = new List<int> { 1, 2, 3 };

            var csv = list.ToCsv();

            Assert.AreEqual("1,2,3", csv);
        }
        
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
