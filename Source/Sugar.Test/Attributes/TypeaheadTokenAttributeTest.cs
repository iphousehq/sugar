using System;
using NUnit.Framework;

namespace Sugar.Attributes
{
    [TestFixture]
    public class TypeaheadTokenAttributeTest
    {
        [Test]
        public void TestSingleWord()
        {
            var result = new TypeaheadTokenAttribute("gb");

            Assert.AreEqual("gb", result.Token);
        }

        [Test]
        public void TestMultipleWordsNotNullOrEmptyValues()
        {
            Assert.Throws<ArgumentException>(() => new TypeaheadTokenAttribute(null));
            Assert.Throws<ArgumentException>(() => new TypeaheadTokenAttribute(""));
            Assert.Throws<ArgumentException>(() => new TypeaheadTokenAttribute("  "));
        }

        [Test]
        public void TestMultipleWordsNotAllowMultipleWords()
        {
            Assert.Throws<ArgumentException>(() => new TypeaheadTokenAttribute("great britain"));
        }
    }
}
