using NUnit.Framework;

namespace Sugar.Command
{
    [TestFixture]
    public class ParametersTest
    {
        [Test]
        public void TestSetCurrent()
        {
            Parameters.SetCurrent("-list -zones");

            Assert.IsFalse(Parameters.Directory.StartsWith("file://"));

            Assert.AreEqual(2, Parameters.Current.Count);
        }
    }
}
