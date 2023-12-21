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

            Assert.That(type, Is.EqualTo("System.String"));
        }

        [Test]
        public void TestServiceTypeKeyForGenericType()
        {
            var type = typeof(IList<string>).ToGenericFullName();

            Assert.That(type, Is.EqualTo("System.Collections.Generic.IList<String>"));
        }

        [Test]
        public void TestServiceTypeKeyForGenericTypeDefinition()
        {
            var type = typeof(IList<>).ToGenericFullName();

            Assert.That(type, Is.EqualTo("System.Collections.Generic.IList<T>"));
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
            Assert.That(typeof(TestType).ImplementsInterface(typeof(IDisposable)), Is.True);
        }

        [Test]
        public void TestTypeIsNotDisposable()
        {
            Assert.That(typeof(TypeExtensionsTest).ImplementsInterface(typeof(IDisposable)), Is.False);
        }
    }
}
