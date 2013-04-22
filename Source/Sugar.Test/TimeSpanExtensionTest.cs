using System;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class TimeSpanExtensionTest
    {
        [Test]
        public void TestToReadableStringWithSecond()
        {
            var result = TimeSpan.FromSeconds(1).ToReadableString();

            Assert.AreEqual("1 second", result);
        }

        [Test]
        public void TestToReadableStringWithSeconds()
        {
            var result = TimeSpan.FromSeconds(5).ToReadableString();

            Assert.AreEqual("5 seconds", result);
        }

        [Test]
        public void TestToReadableStringWithMinute()
        {
            var result = TimeSpan.FromMinutes(1).ToReadableString();

            Assert.AreEqual("1 minute", result);
        }

        [Test]
        public void TestToReadableStringWithMinutes()
        {
            var result = TimeSpan.FromMinutes(5).ToReadableString();

            Assert.AreEqual("5 minutes", result);
        }

        [Test]
        public void TestToReadableStringWithHour()
        {
            var result = TimeSpan.FromHours(1).ToReadableString();

            Assert.AreEqual("1 hour", result);
        }

        [Test]
        public void TestToReadableStringWithHours()
        {
            var result = TimeSpan.FromHours(5).ToReadableString();

            Assert.AreEqual("5 hours", result);
        }

        [Test]
        public void TestToReadableStringWithDay()
        {
            var result = TimeSpan.FromDays(1).ToReadableString();

            Assert.AreEqual("1 day", result);
        }

        [Test]
        public void TestToReadableStringWithDays()
        {
            var result = TimeSpan.FromDays(5).ToReadableString();

            Assert.AreEqual("5 days", result);
        }

        [Test]
        public void TestToReadableStringWithDaysAndHour()
        {
            var result = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(5)).ToReadableString();

            Assert.AreEqual("5 days, 5 hours", result);
        }

        [Test]
        public void TestToReadableStringWithDaysAndHourIgnoreHour()
        {
            var result = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(5)).ToReadableString(TimeSpanPart.Day);

            Assert.AreEqual("5 days", result);
        }

        [Test]
        public void TestToReadableStringNoTime()
        {
            var result = TimeSpan.FromSeconds(0).ToReadableString();

            Assert.AreEqual("", result);
        }

        [Test]
        public void TestToReadableStringLessThanASecond()
        {
            var result = TimeSpan.FromMilliseconds(10).ToReadableString();

            Assert.AreEqual("Less than a second", result);
        }
    }
}