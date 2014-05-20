using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class CollectionExtensionsTest
    {
        [Test]
        public void TestAddIfNotExistsWhenItemAlreadyInCollection()
        {
            ICollection<string> collection = new[] {"boo"};

            collection.AddIfNotExists("boo");

            Assert.AreEqual(1, collection.Count);
        }

        [Test]
        public void TestAddIfNotExistsWhenItemNotAlreadyInCollection()
        {
            ICollection<string> collection = new List<string> { "boo" };

            collection.AddIfNotExists("baa");

            Assert.AreEqual(2, collection.Count);
            Assert.AreEqual("boo", collection.ElementAt(0));
            Assert.AreEqual("baa", collection.ElementAt(1));
        }

        [Test]
        public void TestAddIfNotExistsWhenItemNotAlreadyInCollectionButCollectionOfFixedSize()
        {
            ICollection<string> collection = new[] {"boo"};

            Assert.Throws<NotSupportedException>(() => collection.AddIfNotExists("baa"));
        }
    }
}