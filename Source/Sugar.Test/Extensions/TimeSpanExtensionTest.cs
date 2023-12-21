using System;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class TimeSpanExtensionTest
    {
        [Test]
        public void TestYears()
        {
            var timeSpan = new TimeSpan(400, 0, 0, 0);

            var result = timeSpan.Years();

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestMonths()
        {
            var timeSpan = new TimeSpan(40, 0, 0, 0);

            var result = timeSpan.Months();

            Assert.That(result, Is.EqualTo(1));
        }


        [Test]
        public void TestHumaniseWithNoTicks()
        {
            var timespan = new TimeSpan();

            Assert.That(timespan.Ticks, Is.EqualTo(0));
            Assert.That(timespan.Humanise(), Is.Empty);
        }

        [Test]
        public void TestHumaniseWithSecond()
        {
            var result = TimeSpan.FromSeconds(1).Humanise();

            Assert.That(result, Is.EqualTo("1 second"));
        }

        [Test]
        public void TestHumaniseWithSeconds()
        {
            var result = TimeSpan.FromSeconds(5).Humanise();

            Assert.That(result, Is.EqualTo("5 seconds"));
        }

        [Test]
        public void TestHumaniseWithMinute()
        {
            var result = TimeSpan.FromMinutes(1).Humanise();

            Assert.That(result, Is.EqualTo("1 minute"));
        }

        [Test]
        public void TestHumaniseWithMinutes()
        {
            var result = TimeSpan.FromMinutes(5).Humanise();

            Assert.That(result, Is.EqualTo("5 minutes"));
        }

        [Test]
        public void TestHumaniseWithHour()
        {
            var result = TimeSpan.FromHours(1).Humanise();

            Assert.That(result, Is.EqualTo("1 hour"));
        }

        [Test]
        public void TestHumaniseWithHours()
        {
            var result = TimeSpan.FromHours(5).Humanise();

            Assert.That(result, Is.EqualTo("5 hours"));
        }

        [Test]
        public void TestHumaniseWithDay()
        {
            var result = TimeSpan.FromDays(1).Humanise();

            Assert.That(result, Is.EqualTo("1 day"));
        }

        [Test]
        public void TestHumaniseWithDays()
        {
            var result = TimeSpan.FromDays(5).Humanise();

            Assert.That(result, Is.EqualTo("5 days"));
        }

        [Test]
        public void TestHumaniseWithDaysAndHour()
        {
            var result = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(5)).Humanise();

            Assert.That(result, Is.EqualTo("5 days, 5 hours"));
        }

        [Test]
        public void TestHumaniseWithDaysAndHourIgnoreHour()
        {
            var result = TimeSpan.FromDays(5).Add(TimeSpan.FromHours(5)).Humanise(TimeSpanPart.Day);

            Assert.That(result, Is.EqualTo("5 days"));
        }

        [Test]
        public void TestHumaniseLessThanASecond()
        {
            var result = TimeSpan.FromMilliseconds(10).Humanise();

            Assert.That(result, Is.EqualTo("Less than a second"));
        }

        [Test]
        public void TestToReadbleStringInSecondsOnlyWhenLessThanOneSecond()
        {
            var result = TimeSpan.FromMilliseconds(500).Humanise();

            Assert.That(result, Is.EqualTo("Less than a second"));
        }

        [Test]
        public void TestToReadbleStringInMinutesOnlyWhenLessThanOneMinute()
        {
            var result = TimeSpan.FromSeconds(30).Humanise(TimeSpanPart.Minute);

            Assert.That(result, Is.EqualTo("Less than a minute"));
        }

        [Test]
        public void TestToReadbleStringInDaysOnlyWhenLessThanOneDay()
        {
            var result = TimeSpan.FromMinutes(180).Humanise(TimeSpanPart.Day);

            Assert.That(result, Is.EqualTo("Less than a day"));
        }
        
        [Test]
        public void TestLargeTimeSpanWithLowPrecision()
        {
            var timeSpan = new TimeSpan(23746876111100000);

            var result = timeSpan.Humanise(TimeSpanPart.Day | TimeSpanPart.Hour | TimeSpanPart.Minute);

            Assert.That(result, Is.EqualTo("27484 days, 19 hours, 26 minutes"));
        }

        [Test]
        public void TestTimeSpanSmallerThanPrecision()
        {
            var timeSpan = new TimeSpan(11100000);

            var result = timeSpan.Humanise(TimeSpanPart.Day | TimeSpanPart.Hour | TimeSpanPart.Minute);

            Assert.That(result, Is.EqualTo("Less than a minute"));
        }

        [Test]
        public void TestTimeSpanWithNegativeHours()
            
        {
            var timeSpan = new TimeSpan(-4, 0, 0);
            var result = timeSpan.Humanise();

            Assert.That(result, Is.EqualTo("-4 hours"));
        }
    }
}
