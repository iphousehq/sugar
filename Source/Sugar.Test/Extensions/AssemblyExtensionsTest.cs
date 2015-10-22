using System;
using System.Linq;
using NUnit.Framework;
using Sugar.Extensions.AssemblyExtensionsTestAdditional;

#region Test Namespaces

namespace Sugar.Extensions.AssemblyExtensionsTestClasses
{
    public class ClassOne {}

    public class ClassTwo {}

    public class ClassThree {}
}

namespace Sugar.Extensions.AssemblyExtensionsTestAdditional
{
    public class AttributeOne : Attribute {}

    public class ClassFour {}

    [AttributeOne]
    public class ClassFive {}
}

#endregion

namespace Sugar.Extensions
{
    [TestFixture]
    public class AssemblyExtensionsTest
    {
        [Test]
        public void TestGetAllTypes()
        {
            var assembly = GetType().Assembly;

            var types = AssemblyExtensions.GetTypes(assembly)
                                          .ToArray();

            Assert.Less(10, types.Length);
        }

        [Test]
        public void TestGetAllTypesInANamespaceWhenNamespaceDoesntExist()
        {
            var types = GetType().Assembly.GetTypes("Comsec.Foo.Bar.Baz");

            Assert.AreEqual(0, types.Count());
        }

        [Test]
        public void TestGetTypes()
        {
            var types = GetType().Assembly.GetTypes("Sugar.Extensions.AssemblyExtensionsTestClasses")
                                 .ToArray();

            Assert.AreEqual(3, types.Length);
        }

        [Test]
        public void TestGetTypesWithMultipleNamespaces()
        {
            var types = GetType().Assembly.GetTypes("Sugar.Extensions.AssemblyExtensionsTestClasses", "Sugar.Extensions.AssemblyExtensionsTestAdditional")
                                 .ToArray();

            Assert.AreEqual(6, types.Length);
        }

        [Test]
        public void TestGetTypesWithAttribute()
        {
            var types = GetType().Assembly.GetTypesWith<AttributeOne>()
                                 .ToArray();

            Assert.AreEqual(1, types.Length);
        }
    }
}
