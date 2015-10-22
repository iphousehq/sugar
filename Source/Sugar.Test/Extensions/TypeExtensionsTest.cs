using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Sugar.Extensions
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

        private class TestType : IDisposable
        {
            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <filterpriority>2</filterpriority>
            public void Dispose()
            {
            }
        }

        [Test]
        public void TestTypeIsDisposable()
        {
            Assert.IsTrue(typeof(TestType).ImplementsInterface(typeof(IDisposable)));
        }

        [Test]
        public void TestTypeIsNotDisposable()
        {
            Assert.IsFalse(typeof(TypeExtensionsTest).ImplementsInterface(typeof(IDisposable)));
        }
    }
}
