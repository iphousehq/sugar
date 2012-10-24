using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class CollectionExtensionsTest
    {
        [Test]
        public void TestAddToCollectionAlreadyAdded()
        {
            const string s = "test";

            var list = new List<String> { s };
            list.AddIfNotExists(s);

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestAddToCollectionNotAlreadyAdded()
        {
            const string s = "test";

            var list = new List<String>();
            list.AddIfNotExists(s);

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestGetMaximumIndexUsingFilterNoneMatch()
        {
            var collection = new List<String>
            {
                "test",
                "something"
            };

            var result = collection.GetMaximumIndexUsingFilter(x => x.Length > 10);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestGetMaximumIndexUsingFilterOneMatches()
        {
            var collection = new List<String>
            {
                "test",
                "something"
            };

            var result = collection.GetMaximumIndexUsingFilter(x => x.Length > 4);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestGetMaximumIndexUsingFilterMultipleMatch()
        {
            var collection = new List<String>
            {
                "test",
                "something"
            };

            var result = collection.GetMaximumIndexUsingFilter(x => x.Length > 2);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestGetIndexUsingFilterNotInList()
        {
            var collection = new List<String>
            {
                "test",
                "something"
            };

            var result = collection.GetIndexUsingFilter(x => x == "no");

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestGetIndexUsingFilterInList()
        {
            var collection = new List<String>
            {
                "test",
                "something"
            };

            var result = collection.GetIndexUsingFilter(x => x == "test");

            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestRemoveAndInsertOneItemDoesNotExist()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            Assert.Throws<ArgumentOutOfRangeException>(() => collection.RemoveAndInsertAt(0, 3));
        }

        [Test]
        public void TestRemoveAndInsertItems()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            var results = collection.RemoveAndInsertAt(1, 0);

            Assert.AreEqual("test2", results[0]);
            Assert.AreEqual("test1", results[1]);
            Assert.AreEqual("test3", results[2]);
        }

        [Test]
        public void TestRemoveAndInsertItemsSameIndex()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            var results = collection.RemoveAndInsertAt(0, 0);

            Assert.AreEqual("test1", results[0]);
            Assert.AreEqual("test2", results[1]);
            Assert.AreEqual("test3", results[2]);
        }

        [Test]
        public void TestRemoveAndInsertItemsRemoveIndexLowerThanInsert()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            var results = collection.RemoveAndInsertAt(0, 1);

            Assert.AreEqual("test2", results[0]);
            Assert.AreEqual("test1", results[1]);
            Assert.AreEqual("test3", results[2]);
        }

        [Test]
        public void TestRemoveAndInsertItemsAtEnd()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            var results = collection.RemoveAndInsertAt(0, 2);

            Assert.AreEqual("test2", results[0]);
            Assert.AreEqual("test3", results[1]);
            Assert.AreEqual("test1", results[2]);
        }

        [Test]
        public void TestRemovePredicateFalse()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            collection.RemoveIf(s => s == "test4");

            Assert.AreEqual(3, collection.Count);
        }

        [Test]
        public void TestRemovePredicateTrue()
        {
            var collection = new List<String>
            {
                "test1",
                "test2",
                "test3"
            };

            collection.RemoveIf(s => s == "test3");

            Assert.AreEqual(2, collection.Count);
        }
    }
}
