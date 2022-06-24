using System;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class EnumExtensionsTest
    {
        private enum SomeEnum
        {
            [System.ComponentModel.Description("Bob Value")]
            Bob = 40,
            Thursday = 50,
            [System.ComponentModel.Description("Equals Value")]
            Equals = 60
        }

        [Flags]
        private enum SomeFlagsEnum
        {
            Bob = 1 << 0,
            Thursday = 1 << 1
        }

        [Test]
        public void TestGetFlagsEmpty()
        {
            const SomeFlagsEnum input = new SomeFlagsEnum();

            var result = input.GetFlags().ToList();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void TestGetFlagsSingle()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob;

            var result = input.GetFlags().ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(SomeFlagsEnum.Bob, result[0]);
        }

        [Test]
        public void TestGetFlagsMultiple()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob | SomeFlagsEnum.Thursday;

            var result = input.GetFlags().ToList();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(SomeFlagsEnum.Bob, result[0]);
            Assert.AreEqual(SomeFlagsEnum.Thursday, result[1]);
        }

        [Test]
        public void TestGetAttribute()
        {
            var result = SomeEnum.Bob.GetAttributeFromEnumConstant<System.ComponentModel.DescriptionAttribute>();

            Assert.NotNull(result);
        }

        [Test]
        public void TestGetAttributeNotPresent()
        {
            var result = SomeEnum.Thursday.GetAttributeFromEnumConstant<System.ComponentModel.DescriptionAttribute>();

            Assert.Null(result);
        }

        [Test]
        public void TestGetAttributes()
        {
            var result = SomeEnum.Bob.GetAttributesFromEnumConstant<System.ComponentModel.DescriptionAttribute>();

            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void TestGetAttributeProperty()
        {
            var result = SomeEnum.Bob.GetAttributePropertyFromEnumConstant<System.ComponentModel.DescriptionAttribute, string>(x => x.Description, "default");

            Assert.AreEqual("Bob Value", result);
        }

        [Test]
        public void TestGetAttributePropertyNotPresent()
        {
            var result = SomeEnum.Thursday.GetAttributePropertyFromEnumConstant<System.ComponentModel.DescriptionAttribute, string>(x => x.Description, "default");

            Assert.AreEqual("default", result);
        }

        [Test]
        public void TestGetDescriptionWhenNull()
        {
            var result = EnumExtensions.GetDescription(null);

            Assert.AreSame(string.Empty, result);
        }

        [Test]
        public void TestGetDescription()
        {
            var result = SomeEnum.Bob.GetDescription();

            Assert.AreEqual("Bob Value", result);
        }

        [Test]
        public void TestGetDescriptionNotPresent()
        {
            var result = SomeEnum.Thursday.GetDescription();

            Assert.AreEqual("Thursday", result);
        }

        [Test]
        public void TestGetDescriptionForEqualsMember()
        {
            var result = SomeEnum.Equals.GetDescription();

            Assert.AreEqual("Equals Value", result);
        }
    }
}
