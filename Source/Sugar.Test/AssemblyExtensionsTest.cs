using System.Linq;
using NUnit.Framework;

namespace Sugar
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
            var types = GetType().Assembly.GetTypes("Sugar.Xml")
                                 .ToArray();

            Assert.AreEqual(1, types.Length);
            Assert.AreEqual("Sugar.Xml", types[0].Namespace);
        }

        [Test]
        public void TestGetTypesWithMultipleNamespaces()
        {
            var types = GetType().Assembly.GetTypes(new[] {"Sugar.Xml", "Sugar.Net"})
                                 .ToArray();

            Assert.AreEqual(7, types.Length);
            Assert.AreEqual("Sugar.Net", types[0].Namespace);
            Assert.AreEqual("Sugar.Xml", types[6].Namespace);
        }
    }
}
