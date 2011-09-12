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
    }
}
