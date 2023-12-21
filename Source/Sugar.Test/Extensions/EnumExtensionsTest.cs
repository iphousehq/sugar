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

            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestGetFlagsSingle()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob;

            var result = input.GetFlags().ToList();

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(SomeFlagsEnum.Bob));
        }

        [Test]
        public void TestGetFlagsMultiple()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob | SomeFlagsEnum.Thursday;

            var result = input.GetFlags().ToList();

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(SomeFlagsEnum.Bob));
            Assert.That(result[1], Is.EqualTo(SomeFlagsEnum.Thursday));
        }

        [Test]
        public void TestGetAttribute()
        {
            var result = SomeEnum.Bob.GetAttributeFromEnumConstant<System.ComponentModel.DescriptionAttribute>();

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void TestGetAttributeNotPresent()
        {
            var result = SomeEnum.Thursday.GetAttributeFromEnumConstant<System.ComponentModel.DescriptionAttribute>();

            Assert.That(result, Is.Null);
        }

        [Test]
        public void TestGetAttributes()
        {
            var result = SomeEnum.Bob.GetAttributesFromEnumConstant<System.ComponentModel.DescriptionAttribute>();

            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestGetAttributeProperty()
        {
            var result = SomeEnum.Bob.GetAttributePropertyFromEnumConstant<System.ComponentModel.DescriptionAttribute, string>(x => x.Description, "default");

            Assert.That(result, Is.EqualTo("Bob Value"));
        }

        [Test]
        public void TestGetAttributePropertyNotPresent()
        {
            var result = SomeEnum.Thursday.GetAttributePropertyFromEnumConstant<System.ComponentModel.DescriptionAttribute, string>(x => x.Description, "default");

            Assert.That(result, Is.EqualTo("default"));
        }

        [Test]
        public void TestGetDescriptionWhenNull()
        {
            var result = EnumExtensions.GetDescription(null);

            Assert.That(result, Is.SameAs(string.Empty));
        }

        [Test]
        public void TestGetDescription()
        {
            var result = SomeEnum.Bob.GetDescription();

            Assert.That(result, Is.EqualTo("Bob Value"));
        }

        [Test]
        public void TestGetDescriptionNotPresent()
        {
            var result = SomeEnum.Thursday.GetDescription();

            Assert.That(result, Is.EqualTo("Thursday"));
        }

        [Test]
        public void TestGetDescriptionForEqualsMember()
        {
            var result = SomeEnum.Equals.GetDescription();

            Assert.That(result, Is.EqualTo("Equals Value"));
        }
    }
}
