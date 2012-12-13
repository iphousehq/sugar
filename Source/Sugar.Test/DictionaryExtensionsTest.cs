using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class DictionaryExtensionsTest
    {
        [Test]
        public void TestGetKeysFromValueWithNullDictionary()
        {
            Assert.Throws<ArgumentNullException>(() => ((IDictionary<int, int>)null).GetKeysFromValue(0));
        }

        [Test]
        public void TestGetKeysFromValueNotIncludedValueType()
        {
            var dictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1},
                {2, 2}
            };

            var results = dictionary.GetKeysFromValue(3).ToList();

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void TestGetKeysFromValueSingleResultValueType()
        {
            var dictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1},
                {2, 2}
            };

            var results = dictionary.GetKeysFromValue(2).ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(2, results[0]);
        }

        [Test]
        public void TestGetKeysFromValueMultipleResultsValueType()
        {
            var dictionary = new Dictionary<int, int>
            {
                {0, 0},
                {1, 1},
                {2, 2},
                {3, 2}
            };

            var results = dictionary.GetKeysFromValue(2).ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(2, results[0]);
            Assert.AreEqual(3, results[1]);
        }

        [Test]
        public void TestGetKeysFromValueNotIncludedReferenceType()
        {
            var dictionary = new Dictionary<int, String>
            {
                {0, "0"},
                {1, "1"},
                {2, "2"}
            };

            var results = dictionary.GetKeysFromValue("3").ToList();

            Assert.AreEqual(0, results.Count);
        }

        [Test]
        public void TestGetKeysFromValueeSingleResultReferenceTyp()
        {
            var dictionary = new Dictionary<int, String>
            {
                {0, "0"},
                {1, "1"},
                {2, "2"}
            };

            var results = dictionary.GetKeysFromValue("2").ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(2, results[0]);
        }

        [Test]
        public void TestGetKeysFromValueMultipleResultsReferenceType()
        {
            var dictionary = new Dictionary<int, String>
            {
                {0, "0"},
                {1, "1"},
                {2, "2"},
                {3, "2"}
            };

            var results = dictionary.GetKeysFromValue("2").ToList();

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(2, results[0]);
            Assert.AreEqual(3, results[1]);
        }

        [Test]
        public void TestPairedWith()
        {
            var result = "key".PairedWith(5);

            Assert.AreEqual("key", result.Key);
            Assert.AreEqual(5, result.Value);
        }
    }
}