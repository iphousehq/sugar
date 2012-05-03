using System;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class DoubleExtensionsTest
    {
        [Test]
        public void TestFromUnixTimestamp()
        {
            var time = 1293840000.0d.FromUnixTimestamp();

            Assert.AreEqual(new DateTime(2011, 1, 1), time);
        }
    }
}
