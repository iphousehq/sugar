using System;
using System.Collections.Generic;
using System.Linq;
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

        [Flags]
        private enum SomeFlagsEnum
        {
            Bob = 1 << 0,
            Thursday = 1 << 1
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

        [Test]
        public void TestGetFlagsSingle()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob;

            var result = input.GetFlags().ToList();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(SomeFlagsEnum.Bob, result[0]);
        }

        [Test]
        public void TestGetFlagsMultiple()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob | SomeFlagsEnum.Thursday;

            var result = input.GetFlags().ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(SomeFlagsEnum.Bob, result[0]);
            Assert.AreEqual(SomeFlagsEnum.Thursday, result[1]);
        }

        [Test]
        public void TestGetFlagsValuesNotEnum()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob | SomeFlagsEnum.Thursday;

            try
            {
                input.GetFlagsValues<int>();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("TEnum must be an enumeration", ex.Message);
            }
        }

        [Test]
        public void TestGetFlagsValuesSingle()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Thursday;

            var result = input.GetFlagsValues<SomeFlagsEnum>().ToList();

            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(2, result[0]);
        }

        [Test]
        public void TestGetFlagsValuesMultiple()
        {
            const SomeFlagsEnum input = SomeFlagsEnum.Bob | SomeFlagsEnum.Thursday;

            var result = input.GetFlagsValues<SomeFlagsEnum>().ToList();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }

        [Test]
        public void TestCombineFlagsNotEnum()
        {
            var list = new List<int> {1, 2};

            try
            {
                list.CombineToFlagsEnum<int>();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("TEnum must be an enumeration", ex.Message);
            }
        }

        [Test]
        public void TestCombineFlags()
        {
            var list = new List<int> { 1, 2 };

            var result = list.CombineToFlagsEnum<SomeFlagsEnum>();

            Assert.True(result.HasFlag(SomeFlagsEnum.Bob));
            Assert.True(result.HasFlag(SomeFlagsEnum.Thursday));
        }

        [Test]
        public void TestCombineFlagsSingle()
        {
            var list = new List<int> { 2 };

            var result = list.CombineToFlagsEnum<SomeFlagsEnum>();

            Assert.True(result.HasFlag(SomeFlagsEnum.Thursday));
        }

        [Test]
        public void TestCombineFlagsOutsideRange()
        {
            var list = new List<int> { 1, 2, 4 };

            var result = list.CombineToFlagsEnum<SomeFlagsEnum>();

            Assert.True(result.HasFlag(SomeFlagsEnum.Bob));
            Assert.True(result.HasFlag(SomeFlagsEnum.Thursday));
        }

        [Test]
        public void TestCombineFlagsSingleOutsideRange()
        {
            var list = new List<int> { 2, 4 };

            var result = list.CombineToFlagsEnum<SomeFlagsEnum>();

            Assert.True(result.HasFlag(SomeFlagsEnum.Thursday));
        }
    }
}
