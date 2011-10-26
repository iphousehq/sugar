using System.Collections.Generic;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class TypeExtensionsTest
    {
        [Test]
        public void TestServiceTypeKey()
        {
            var type = typeof(string).ToGenericFullName();

            Assert.AreEqual("System.String", type);
        }

        [Test]
        public void TestServiceTypeKeyForGenericType()
        {
            var type = typeof(IList<string>).ToGenericFullName();

            Assert.AreEqual("System.Collections.Generic.IList<String>", type);
        }

        [Test]
        public void TestServiceTypeKeyForGenericTypeDefinition()
        {
            var type = typeof(IList<>).ToGenericFullName();

            Assert.AreEqual("System.Collections.Generic.IList<T>", type);
        }
    }
}
