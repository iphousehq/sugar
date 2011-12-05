using System;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class EnumExtensionsTest
    {
        private enum SomeEnum
        {
            Bob = 40,
            Thursday = 50
        }

        [Test]
        public void TestConvertEnumToAnotherEnumByValue()
        {
            var result = DayOfWeek.Thursday.ToEnum<SomeEnum>();

            Assert.AreEqual("SomeEnum", result.GetType().Name);
            Assert.AreEqual("Thursday", result.ToString());
        }

        [Test]
        public void TestConvertEnumToNotAnEnumThrowsAnException()
        {
            try
            {
                DayOfWeek.Tuesday.ToEnum<DateTime>();
            }
            catch(Exception ex)
            {
                Assert.AreEqual(typeof(ArgumentException), ex.GetType());
                Assert.AreEqual("TResult must be an enumeration", ex.Message);
            }
        }

        [Test]
        public void TestConvertEnumToNotAnEnumButNoMatch()
        {
            try
            {
                DayOfWeek.Tuesday.ToEnum<SomeEnum>();
            }
            catch (InvalidCastException ex)
            {
                Assert.AreEqual(typeof(InvalidCastException), ex.GetType());
                Assert.AreEqual("Error converting System.DayOfWeek (value 'Tuesday') to Sugar.EnumExtensionsTest+SomeEnum", ex.Message);
            }
        }
    }
}
