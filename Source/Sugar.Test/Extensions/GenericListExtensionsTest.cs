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

            Assert.That(list.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestAddToCollectionNotAlreadyAdded()
        {
            const string s = "test";

            var list = new List<string>();
            list.AddIfNotExists(s);

            Assert.That(list.Count, Is.EqualTo(1));
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

            Assert.That(results[0], Is.EqualTo("test2"));
            Assert.That(results[1], Is.EqualTo("test1"));
            Assert.That(results[2], Is.EqualTo("test3"));
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

            Assert.That(results[0], Is.EqualTo("test1"));
            Assert.That(results[1], Is.EqualTo("test2"));
            Assert.That(results[2], Is.EqualTo("test3"));
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

            Assert.That(results[0], Is.EqualTo("test2"));
            Assert.That(results[1], Is.EqualTo("test1"));
            Assert.That(results[2], Is.EqualTo("test3"));
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

            Assert.That(results[0], Is.EqualTo("test2"));
            Assert.That(results[1], Is.EqualTo("test3"));
            Assert.That(results[2], Is.EqualTo("test1"));
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

            Assert.That(collection.Count, Is.EqualTo(3));
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

            Assert.That(collection.Count, Is.EqualTo(2));
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

            Assert.That(results.Count, Is.EqualTo(3));
            Assert.That(results[0].Count(), Is.EqualTo(2));
            Assert.That(results[1].Count(), Is.EqualTo(2));
            Assert.That(results[2].Count(), Is.EqualTo(2));
            Assert.That(results[0].ElementAt(0), Is.EqualTo("one"));
            Assert.That(results[1].ElementAt(0), Is.EqualTo("three"));
            Assert.That(results[2].ElementAt(0), Is.EqualTo("five"));
        }
    }
}
