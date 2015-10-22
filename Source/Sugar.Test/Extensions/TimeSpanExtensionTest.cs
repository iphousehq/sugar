using System;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class TimeSpanExtensionTest
    {
        [Test]
        public void TestHumaniseWithNoTicks()
        {
            var timespan = new TimeSpan();

            Assert.AreEqual(0, timespan.Ticks);
            Assert.IsEmpty(timespan.Humanise());
        }

        [Test]
        public void TestHumaniseWithSecond()
        {
            var result = TimeSpan.FromSeconds(1).Humanise();

            Assert.AreEqual("1 second", result);
        }

        [Test]
        public void TestHumaniseWithSeconds()
        {
            var result = TimeSpan.FromSeconds(5).Humanise();

            Assert.AreEqual("5 seconds", result);
        }

        [Test]
        public void TestHumaniseWithMinute()
        {
            var result = TimeSpan.FromMinutes(1).Humanise();

            Assert.AreEqual("1 minute", result);
        }

        [Test]
        public void TestHumaniseWithMinutes()
        {
            var result = TimeSpan.FromMinutes(5).Humanise();

            Assert.AreEqual("5 minutes", result);
        }

        [Test]
        public void TestHumaniseWithHour()
        {
            var result = TimeSpan.FromHours(1).Humanise();

            Assert.AreEqual("1 hour", result);
        }

        [Test]
        public void TestHumaniseWithHours()
        {
            var result = TimeSpan.FromHours(5).Humanise();

            Assert.AreEqual("5 hours", result);
        }

        [Test]
        public void TestHumaniseWithDay()
        {
            var result = TimeSpan.FromDays(1).Humanise();

            Assert.AreEqual("1 day", result);
        }

        [Test]
        public void TestHumaniseWithDays()
        {
            var result = TimeSpan.FromDays(5).Humanise();

            Assert.AreEqual("5 days", result);
        }

        [Test]
        public void TestHumaniseWithDaysAndHour()
        {
            var result = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(5)).Humanise();

            Assert.AreEqual("5 days, 5 hours", result);
        }

        [Test]
        public void TestHumaniseWithDaysAndHourIgnoreHour()
        {
            var result = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(5)).Humanise(TimeSpanPart.Day);

            Assert.AreEqual("5 days", result);
        }

        [Test]
        public void TestHumaniseLessThanASecond()
        {
            var result = TimeSpan.FromMilliseconds(10).Humanise();

            Assert.AreEqual("Less than a second", result);
        }

        [Test]
        public void TestToReadbleStringInSecondsOnlyWhenLessThanOneSecond()
        {
            var result = TimeSpan.FromMilliseconds(500).Humanise();

            Assert.AreEqual("Less than a second", result);
        }

        [Test]
        public void TestToReadbleStringInMinutesOnlyWhenLessThanOneMinute()
        {
            var result = TimeSpan.FromSeconds(30).Humanise(TimeSpanPart.Minute);

            Assert.AreEqual("Less than a minute", result);
        }

        [Test]
        public void TestToReadbleStringInDaysOnlyWhenLessThanOneDay()
        {
            var result = TimeSpan.FromMinutes(180).Humanise(TimeSpanPart.Day);

            Assert.AreEqual("Less than a day", result);
        }

        [Test]
        public void TestYears()
        {
            var timeSpan = new TimeSpan(400, 0, 0, 0);

            var result = timeSpan.Years();

            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestMonths()
        {
            var timeSpan = new TimeSpan(40, 0, 0, 0);

            var result = timeSpan.Months();

            Assert.AreEqual(1, result);
        }
    }
}