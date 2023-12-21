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

            Assert.That(types.Length, Is.GreaterThan(10));;
        }

        [Test]
        public void TestGetAllTypesInANamespaceWhenNamespaceDoesntExist()
        {
            var types = GetType().Assembly.GetTypes("Comsec.Foo.Bar.Baz");

            Assert.That(types.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestGetTypes()
        {
            var types = GetType().Assembly.GetTypes("Sugar.Extensions.AssemblyExtensionsTestClasses")
                                 .ToArray();

            Assert.That(types.Length, Is.EqualTo(3));
        }

        [Test]
        public void TestGetTypesWithMultipleNamespaces()
        {
            var types = GetType().Assembly.GetTypes("Sugar.Extensions.AssemblyExtensionsTestClasses", "Sugar.Extensions.AssemblyExtensionsTestAdditional")
                                 .ToArray();

            Assert.That(types.Length, Is.EqualTo(6));
        }

        [Test]
        public void TestGetTypesWithAttribute()
        {
            var types = GetType().Assembly.GetTypesWith<AttributeOne>()
                                 .ToArray();

            Assert.That(types.Length, Is.EqualTo(1));
        }
    }
}
