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
            var types = GetType().Assembly.GetTypes();

            Assert.Less(10, types.Length);
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
