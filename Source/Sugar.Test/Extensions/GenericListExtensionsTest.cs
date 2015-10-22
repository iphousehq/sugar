using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class GenericListExtensionsTest
    {
        [Test]
        public void TestAddToCollectionAlreadyAdded()
        {
            const string s = "test";

            var list = new List<string> { s };
            list.AddIfNotExists(s);

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestAddToCollectionNotAlreadyAdded()
        {
            const string s = "test";

            var list = new List<string>();
            list.AddIfNotExists(s);

            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void TestRemoveAndInsertOneItemDoesNotExist()
        {
            var collection = new List<string>
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
            var collection = new List<string>
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
            var collection = new List<string>
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
            var collection = new List<string>
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
            var collection = new List<string>
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
            var collection = new List<string>
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
            var collection = new List<string>
                             {
                                 "test1",
                                 "test2",
                                 "test3"
                             };

            collection.RemoveIf(s => s == "test3");

            Assert.AreEqual(2, collection.Count);
        }

        [Test]
        public void TestChunkify()
        {
            var collection = new List<string>
                                {
                                    "one",
                                    "two",
                                    "three",
                                    "four",
                                    "five",
                                    "six"
                                };

            var results = collection.Chunkify(2).ToList();

            Assert.AreEqual(3, results.Count);
            Assert.AreEqual(2, results[0].Count());
            Assert.AreEqual(2, results[1].Count());
            Assert.AreEqual(2, results[2].Count());
            Assert.AreEqual("one", results[0].ElementAt(0));
            Assert.AreEqual("three", results[1].ElementAt(0));
            Assert.AreEqual("five", results[2].ElementAt(0));
        }
    }
}
