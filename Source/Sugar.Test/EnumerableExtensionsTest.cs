using System.Collections.Generic;
using System.Linq;
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
        public void TestToCsvFromListWithOneEntry()
        {
            var list = new List<int> { 1};

            var csv = list.ToCsv();

            Assert.AreEqual("1", csv);
        }

        [Test]
        public void TestToCsvFromListOfInts()
        {
            var list = new List<int> { 1, 2, 3 };

            var csv = list.ToCsv();

            Assert.AreEqual("1,2,3", csv);
        }

        [Test]
        public void TestToCsvFromListOfIntsWithCustomSeparators()
        {
            var list = new List<int> { 1, 2, 3 };

            var csv = list.ToCsv(", ", " and ");

            Assert.AreEqual("1, 2 and 3", csv);
        }

        [Test]
        public void TestToCsvFromListOfStringsWithCustomSeparators()
        {
            var list = new List<string> { "One", "Two", "Three" };

            var csv = list.ToCsv(", ", " and ");

            Assert.AreEqual("One, Two and Three", csv);
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

#region Distinct Test Class

        internal class DistinctTestClass
        {
            public int Integer { get; set; }

            public uint UnsignedInteger { get; set; }

            public byte Byte { get; set; }

            public double Double { get; set; }

            public float Float { get; set; }

            public bool Boolean { get; set; }

            public string String { get; set; }

            public char Char { get; set; }
        }

#endregion

        [Test]
        public void TestDistinctInt()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {Integer = 1},
                new DistinctTestClass {Integer = 1},
                new DistinctTestClass {Integer = 2},
                new DistinctTestClass {Integer = 3},
            };

            var results = list.Distinct(l => l.Integer).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1, results[0].Integer);
            Assert.AreEqual(2, results[1].Integer);
            Assert.AreEqual(3, results[2].Integer);
        }

        [Test]
        public void TestDistinctUInt()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {UnsignedInteger = 1},
                new DistinctTestClass {UnsignedInteger = 1},
                new DistinctTestClass {UnsignedInteger = 2},
                new DistinctTestClass {UnsignedInteger = 3},
            };

            var results = list.Distinct(l => l.UnsignedInteger).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1, results[0].UnsignedInteger);
            Assert.AreEqual(2, results[1].UnsignedInteger);
            Assert.AreEqual(3, results[2].UnsignedInteger);
        }

        [Test]
        public void TestDistinctByte()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {Byte = 1},
                new DistinctTestClass {Byte = 1},
                new DistinctTestClass {Byte = 2},
                new DistinctTestClass {Byte = 3},
            };

            var results = list.Distinct(l => l.Byte).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1, results[0].Byte);
            Assert.AreEqual(2, results[1].Byte);
            Assert.AreEqual(3, results[2].Byte);
        }

        [Test]
        public void TestDistinctFloat()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {Float = 1.0f},
                new DistinctTestClass {Float = 1.0f},
                new DistinctTestClass {Float = 2.0f},
                new DistinctTestClass {Float = 3.0f},
            };

            var results = list.Distinct(l => l.Float).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1.0f, results[0].Float);
            Assert.AreEqual(2.0f, results[1].Float);
            Assert.AreEqual(3.0f, results[2].Float);
        }

        [Test]
        public void TestDistinctDouble()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {Double = 1.0},
                new DistinctTestClass {Double = 1.0},
                new DistinctTestClass {Double = 2.0},
                new DistinctTestClass {Double = 3.0},
            };

            var results = list.Distinct(l => l.Double).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(1.0, results[0].Double);
            Assert.AreEqual(2.0, results[1].Double);
            Assert.AreEqual(3.0, results[2].Double);
        }

        [Test]
        public void TestDistinctBoolean()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {Boolean = false},
                new DistinctTestClass {Boolean = false},
                new DistinctTestClass {Boolean = true}
            };

            var results = list.Distinct(l => l.Boolean).ToList();

            Assert.AreEqual(2, results.Count);
            Assert.False(results[0].Boolean);
            Assert.True(results[1].Boolean);
        }

        [Test]
        public void TestDistinctString()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {String = "1"},
                new DistinctTestClass {String = "1"},
                new DistinctTestClass {String = "2"},
                new DistinctTestClass {String = "3"},
            };

            var results = list.Distinct(l => l.String).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual("1", results[0].String);
            Assert.AreEqual("2", results[1].String);
            Assert.AreEqual("3", results[2].String);
        }

        [Test]
        public void TestDistinctChar()
        {
            var list = new List<DistinctTestClass>
            {
                new DistinctTestClass {Char = '1'},
                new DistinctTestClass {Char = '1'},
                new DistinctTestClass {Char = '2'},
                new DistinctTestClass {Char = '3'},
            };

            var results = list.Distinct(l => l.Char).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual('1', results[0].Char);
            Assert.AreEqual('2', results[1].Char);
            Assert.AreEqual('3', results[2].Char);
        }
    }
}
