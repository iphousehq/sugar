using System.Linq;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class AssemblyExtensionsTest
    {
        [Test]
        public void TestGetTypes()
        {
            var types = GetType().Assembly.GetTypes("Sugar.Xml");

            Assert.AreEqual(1, types.Count());
        }
    }
}
