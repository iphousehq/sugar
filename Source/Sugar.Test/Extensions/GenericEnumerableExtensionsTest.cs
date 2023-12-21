using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class GenericEnumerableExtensionsTest
    {
        [Test]
        public void TestToCsvFromNull()
        {
            List<int> list = null;

            var csv = list.ToCsv();

            Assert.That(csv, Is.Empty);
        }

        [Test]
        public void TestToCsvFromListWithOneEntry()
        {
            var list = new List<int> { 1 };

            var csv = list.ToCsv();

            Assert.That(csv, Is.EqualTo("1"));
        }

        [Test]
        public void TestToCsvFromListOfInts()
        {
            var list = new List<int> { 1, 2, 3 };

            var csv = list.ToCsv();

            Assert.That(csv, Is.EqualTo("1,2,3"));
        }

        [Test]
        public void TestToCsvFromListOfIntsWithCustomSeparators()
        {
            var list = new List<int> { 1, 2, 3 };

            var csv = list.ToCsv(", ", " and ");

            Assert.That(csv, Is.EqualTo("1, 2 and 3"));
        }

        [Test]
        public void TestToCsvFromListOfStringsWithCustomSeparators()
        {
            var list = new List<string> { "One", "Two", "Three" };

            var csv = list.ToCsv(", ", " and ");

            Assert.That(csv, Is.EqualTo("One, Two and Three"));
        }

        [Test]
        public void TestToCsvAppendsToProvidedStringBuilder()
        {
            var builder = new StringBuilder();

            var list = new List<string> { "One", "Two", "Three" };

            var result = list.ToCsv(builder, ", ", " and ");

            Assert.That(result, Is.SameAs(builder));

            Assert.That(builder.ToString(), Is.EqualTo("One, Two and Three"));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Integer, Is.EqualTo(1));
            Assert.That(results[1].Integer, Is.EqualTo(2));
            Assert.That(results[2].Integer, Is.EqualTo(3));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].UnsignedInteger, Is.EqualTo(1));
            Assert.That(results[1].UnsignedInteger, Is.EqualTo(2));
            Assert.That(results[2].UnsignedInteger, Is.EqualTo(3));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Byte, Is.EqualTo(1));
            Assert.That(results[1].Byte, Is.EqualTo(2));
            Assert.That(results[2].Byte, Is.EqualTo(3));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Float, Is.EqualTo(1.0f));
            Assert.That(results[1].Float, Is.EqualTo(2.0f));
            Assert.That(results[2].Float, Is.EqualTo(3.0f));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Double, Is.EqualTo(1.0));
            Assert.That(results[1].Double, Is.EqualTo(2.0));
            Assert.That(results[2].Double, Is.EqualTo(3.0));
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

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results[0].Boolean, Is.False);
            Assert.That(results[1].Boolean, Is.True);
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].String, Is.EqualTo("1"));
            Assert.That(results[1].String, Is.EqualTo("2"));
            Assert.That(results[2].String, Is.EqualTo("3"));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Char, Is.EqualTo('1'));
            Assert.That(results[1].Char, Is.EqualTo('2'));
            Assert.That(results[2].Char, Is.EqualTo('3'));
        }
    }
}
