using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class DateTimeExtensionTest
    {
        [Test]
        public void TestSpecifyKindOnDateTime()
        {
            var time = new DateTime(2018, 5, 11);

            Assert.That(time.Kind, Is.EqualTo(DateTimeKind.Unspecified));

            var utcTime = time.SpecifyKind(DateTimeKind.Utc);

            Assert.That(time, Is.Not.SameAs(utcTime));

            Assert.That(time, Is.EqualTo(utcTime));
            Assert.That(utcTime.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void TestSpecifyKindOnNullableDateTimeWhenNull()
        {
            DateTime? time = null;
            
            var utcTime = time.SpecifyKind(DateTimeKind.Utc);

            Assert.That(utcTime, Is.Null);
        }

        [Test]
        public void TestSpecifyKindOnNullableDateTimeWithValue()
        {
            DateTime? time = new DateTime(2018, 5, 11);

            Assert.That(time.Value.Kind, Is.EqualTo(DateTimeKind.Unspecified));

            var utcTime = time.SpecifyKind(DateTimeKind.Utc);

            Assert.That(time, Is.Not.SameAs(utcTime));

            Assert.That(time, Is.EqualTo(utcTime));
            Assert.That(utcTime.Value.Kind, Is.EqualTo(DateTimeKind.Utc));
        }

        [Test]
        public void TestToOffsetFromUtc()
        {
            var now = new DateTime(2014, 4, 11, 8, 2, 23, DateTimeKind.Utc);

            var offset = now.ToOffset(new TimeSpan(1, 30, 0));

            Assert.That(offset, Is.EqualTo(new DateTime(2014, 4, 11, 9, 32, 23)));
        }

        /// <summary>
        /// This test will fail on any machine that is not UTC
        /// </summary>
        [Test]
        public void TestToOffsetFromLocal()
        {
            var now = new DateTime(2014, 4, 11, 8, 2, 23, DateTimeKind.Local);

            var offset = now.ToOffset(new TimeSpan(1, 30, 0));

            Assert.That(offset.ToLocalTime(), Is.EqualTo(new DateTime(2014, 4, 11, 9, 32, 23)));
        }

        [Test]
        public void TestMonthsUntil()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 1, 1),
                                   new DateTime(2011, 2, 1),
                                   new DateTime(2011, 3, 1),
                                   new DateTime(2011, 4, 1)
                               };

            var results = new DateTime(2011, 1, 1).MonthsUntil(new DateTime(2011, 4, 1));

            Assert.That(results.Count(), Is.EqualTo(expected.Count));
        }

        [Test]
        public void TestMonthsUntilDaysIncorrectlyFormatted()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 1, 1),
                                   new DateTime(2011, 2, 1),
                                   new DateTime(2011, 3, 1),
                                   new DateTime(2011, 4, 1)
                               };

            var results = new DateTime(2011, 1, 15).MonthsUntil(new DateTime(2011, 4, 23));

            Assert.That(results.Count(), Is.EqualTo(expected.Count));
        }

        [Test]
        public void TestMonthsUntilBoundsAreInCorrect()
        {
            var results = new DateTime(2011, 2, 1).MonthsUntil(new DateTime(2011, 1, 1));

            Assert.That(results.Count(), Is.EqualTo(0));
        }

        [Test]
        public void TestMonthsUntilSameMonth()
        {
            var results = new DateTime(2011, 1, 1).MonthsUntil(new DateTime(2011, 1, 1)).ToList();

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.That(results.First(), Is.EqualTo(new DateTime(2011, 1, 1)));
        }

        [Test]
        public void TestDaysUntil()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 1, 1),
                                   new DateTime(2011, 1, 2),
                                   new DateTime(2011, 1, 3),
                                   new DateTime(2011, 1, 4),
                                   new DateTime(2011, 1, 5),
                                   new DateTime(2011, 1, 6),
                                   new DateTime(2011, 1, 7),
                                   new DateTime(2011, 1, 8),
                                   new DateTime(2011, 1, 9),
                                   new DateTime(2011, 1, 10),
                                   new DateTime(2011, 1, 11),
                                   new DateTime(2011, 1, 12),
                                   new DateTime(2011, 1, 13),
                                   new DateTime(2011, 1, 14),
                                   new DateTime(2011, 1, 15),
                                   new DateTime(2011, 1, 16),
                                   new DateTime(2011, 1, 17),
                                   new DateTime(2011, 1, 18),
                                   new DateTime(2011, 1, 19),
                                   new DateTime(2011, 1, 20),
                               };

            var results = new DateTime(2011, 1, 1).DaysUntil(new DateTime(2011, 1, 20));

            Assert.That(results.Count(), Is.EqualTo(expected.Count));
        }

        [Test]
        public void TestWeeksUntil()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 12, 26),
                                   new DateTime(2012, 1, 2),
                                   new DateTime(2012, 1, 9),
                                   new DateTime(2012, 1, 16),
                                   new DateTime(2012, 1, 23),
                                   new DateTime(2012, 1, 30),
                                   new DateTime(2012, 2, 6),
                               };

            var results = new DateTime(2011, 12, 29).WeeksUntil(new DateTime(2012, 2, 7)).ToList();

            Assert.That(results.Count, Is.EqualTo(expected.Count));
            Assert.That(results.ElementAt(0), Is.EqualTo(expected[0]));
            Assert.That(results.ElementAt(6), Is.EqualTo(expected[6]));
        }

        [Test]
        public void TestWeeksUntilWeekStartWednesday()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 12, 28),
                                   new DateTime(2012, 1, 4),
                                   new DateTime(2012, 1, 11),
                                   new DateTime(2012, 1, 18),
                                   new DateTime(2012, 1, 25),
                                   new DateTime(2012, 2, 1)
                               };

            var results = new DateTime(2011, 12, 29).WeeksUntil(new DateTime(2012, 2, 7), DayOfWeek.Wednesday).ToList();

            Assert.That(results.Count, Is.EqualTo(expected.Count));
            Assert.That(results.ElementAt(0), Is.EqualTo(expected[0]));
            Assert.That(results.ElementAt(5), Is.EqualTo(expected[5]));
        }

        [Test]
        public void TestWeeksUntilWeekStartFriday()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 12, 23),
                                   new DateTime(2011, 12, 30),
                                   new DateTime(2012, 1, 6),
                                   new DateTime(2012, 1, 13),
                                   new DateTime(2012, 1, 20),
                                   new DateTime(2012, 1, 27),
                                   new DateTime(2012, 2, 3)
                               };

            var results = new DateTime(2011, 12, 29).WeeksUntil(new DateTime(2012, 2, 7), DayOfWeek.Friday).ToList();

            Assert.That(results.Count, Is.EqualTo(expected.Count));
            Assert.That(results.ElementAt(0), Is.EqualTo(expected[0]));
            Assert.That(results.ElementAt(6), Is.EqualTo(expected[6]));
        }

        [Test]
        public void TestWeeksUntilLeapYearTest()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 12, 26),
                                   new DateTime(2012, 1, 2),
                                   new DateTime(2012, 1, 9),
                                   new DateTime(2012, 1, 16),
                                   new DateTime(2012, 1, 23),
                                   new DateTime(2012, 1, 30),
                                   new DateTime(2012, 2, 6),
                                   new DateTime(2012, 2, 13),
                                   new DateTime(2012, 2, 20),
                                   new DateTime(2012, 2, 27),
                                   new DateTime(2012, 3, 5),
                                   new DateTime(2012, 3, 12),
                               };

            var results = new DateTime(2011, 12, 26).WeeksUntil(new DateTime(2012, 3, 12)).ToList();

            Assert.That(results.Count, Is.EqualTo(expected.Count));
            Assert.That(results.ElementAt(0), Is.EqualTo(expected[0]));
            Assert.That(results.ElementAt(9), Is.EqualTo(expected[9]));
            Assert.That(results.ElementAt(10), Is.EqualTo(expected[10]));
        }

        [Test]
        public void TestHoursUntil()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 1, 1, 10, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 11, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 12, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 13, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 14, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 15, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 16, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 17, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 18, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 19, 15, 0, 0),
                                   new DateTime(2011, 1, 1, 20, 15, 0, 0)
                               };

            var results = new DateTime(2011, 1, 1, 10, 15, 0, 0).HoursUntil(new DateTime(2011, 1, 1, 20, 15, 0, 0)).ToList();

            Assert.That(results.Count, Is.EqualTo(expected.Count));
            Assert.That(results.ElementAt(0), Is.EqualTo(expected[0]));
            Assert.That(results.ElementAt(9), Is.EqualTo(expected[9]));
            Assert.That(results.ElementAt(10), Is.EqualTo(expected[10]));
        }

        [Test]
        public void TestStartOfWeek()
        {
            // Monday
            var result = new DateTime(2012, 1, 2).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Tuesday
            var result2 = new DateTime(2012, 1, 3).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result2, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Wednesday
            var result3 = new DateTime(2012, 1, 4).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result3, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Thursday
            var result4 = new DateTime(2012, 1, 5).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result4, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Friday
            var result5 = new DateTime(2012, 1, 6).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result5, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Saturday
            var result6 = new DateTime(2012, 1, 7).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result6, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Sunday
            var result7 = new DateTime(2012, 1, 8).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result7, Is.EqualTo(new DateTime(2012, 1, 2)));

            // Sunday
            var result8 = new DateTime(2011, 12, 11).StartOfWeek(DayOfWeek.Monday);
            Assert.That(result8, Is.EqualTo(new DateTime(2011, 12, 5)));
        }

        [Test]
        public void TestEndOfWeek()
        {
            // Monday
            var result = new DateTime(2012, 1, 2).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Tuesday
            var result2 = new DateTime(2012, 1, 3).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result2, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Wednesday
            var result3 = new DateTime(2012, 1, 4).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result3, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Thursday
            var result4 = new DateTime(2012, 1, 5).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result4, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Friday
            var result5 = new DateTime(2012, 1, 6).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result5, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Saturday
            var result6 = new DateTime(2012, 1, 7).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result6, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Sunday
            var result7 = new DateTime(2012, 1, 8).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result7, Is.EqualTo(new DateTime(2012, 1, 8)));

            // Sunday
            var result8 = new DateTime(2011, 12, 11).EndOfWeek(DayOfWeek.Monday);
            Assert.That(result8, Is.EqualTo(new DateTime(2011, 12, 11)));
        }

        [Test]
        public void TestEndOfMonth()
        {
            //beginning
            var result = new DateTime(2012, 1, 1).EndOfMonth();
            Assert.That(result, Is.EqualTo(new DateTime(2012, 1, 31, 23, 59, 59)));

            //middle
            result = new DateTime(2012, 1, 10).EndOfMonth();
            Assert.That(result, Is.EqualTo(new DateTime(2012, 1, 31, 23, 59, 59)));

            //end
            result = new DateTime(2012, 1, 31).EndOfMonth();
            Assert.That(result, Is.EqualTo(new DateTime(2012, 1, 31, 23, 59, 59)));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsNever()
        {
            var dateOne = DateTime.MinValue;
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("never"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOverOneYear()
        {
            var dateOne = new DateTime(2010, 5, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("over a year"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneYear()
        {
            var dateOne = new DateTime(2011, 5, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("a year"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsAboutFourMonths()
        {
            var dateOne = new DateTime(2012, 1, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("about 4 months"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneMonth()
        {
            var dateOne = new DateTime(2012, 4, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("about a month"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsFiveDays()
        {
            var dateOne = new DateTime(2012, 5, 5);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("5 days"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneDay()
        {
            var dateOne = new DateTime(2012, 5, 9);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("a day"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsFiveHours()
        {
            var dateOne = new DateTime(2012, 5, 10, 12, 30, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("5 hours"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneHour()
        {
            var dateOne = new DateTime(2012, 5, 10, 16, 30, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("an hour"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsTenMinutes()
        {
            var dateOne = new DateTime(2012, 5, 10, 17, 20, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("10 minutes"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsAFewMinutes()
        {
            var dateOne = new DateTime(2012, 5, 10, 17, 28, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("a few minutes"));
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsAFewSeconds()
        {
            var dateOne = new DateTime(2012, 5, 10, 17, 30, 25);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.That(result, Is.EqualTo("a few seconds"));
        }

        [Test]
        public void TestHumaniseWhenResultIsNull()
        {
            var result = ((DateTime?)null).Humanise();

            Assert.That(result, Is.EqualTo("never"));
        }

        [Test]
        public void TestHumaniseWhenResultIsNever()
        {
            var date = DateTime.MinValue;

            var result = date.Humanise();

            Assert.That(result, Is.EqualTo("never"));
        }

        [Test]
        public void TestHumaniseWhenResultIsInPast()
        {
            var date = DateTime.UtcNow.AddDays(-5);

            var result = date.Humanise();

            Assert.That(result, Is.EqualTo("5 days ago"));
        }

        [Test]
        public void TestHumaniseWhenResultIsInFuture()
        {
            var date = DateTime.UtcNow.AddDays(5);

            var result = date.Humanise();

            Assert.That(result, Is.EqualTo("in 5 days"));
        }

        [Test]
        public void TestToStringWithOrdinalTest()
        {
            var date = new DateTime(2001, 1, 1);

            var result = date.ToStringWithOrdinal();

            Assert.That(result, Is.EqualTo("1st January 2001"));
        }

        [Test]
        public void TestToListOfSingleDay()
        {
            var result = DateTime.UtcNow.GetPreviousDays(1);

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(DateTime.UtcNow.Date));
        }

        [Test]
        public void TestToListOfTwoDays()
        {
            var result = DateTime.UtcNow.GetPreviousDays(2);

            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(DateTime.UtcNow.Date));
            Assert.That(result[1], Is.EqualTo(DateTime.UtcNow.AddDays(-1).Date));
        }

        [Test]
        public void TestDateIsInBounds()
        {
            var result = new DateTime(2005, 1, 1).InBounds(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1));

            Assert.That(result.Year, Is.EqualTo(2005));
        }

        [Test]
        public void TestDateIsLowerThanBounds()
        {
            var result = new DateTime(1999, 1, 1).InBounds(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1));

            Assert.That(result.Year, Is.EqualTo(DateTime.UtcNow.Year));
        }

        [Test]
        public void TestDateIsHigherThanBounds()
        {
            var result = new DateTime(2015, 1, 1).InBounds(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1));

            Assert.That(result.Year, Is.EqualTo(DateTime.UtcNow.Year));
        }

        [Test]
        public void TestPositiveMonthDifference()
        {
            var now = new DateTime(2011, 06, 01);

            var result = now.MonthDifference(new DateTime(2011, 05, 1));

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void TestNegativeMonthDifference()
        {
            var now = new DateTime(2011, 06, 01);

            var result = now.MonthDifference(new DateTime(2011, 07, 1));

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public void TestToIso8601String()
        {
            var dateTime = new DateTime(2010, 10, 15, 12, 30, 25, DateTimeKind.Local);

            var value = dateTime.ToIso8601String();

            Assert.That(value, Is.EqualTo("20101015T123025"));

            dateTime = new DateTime(2010, 10, 15, 12, 30, 25, DateTimeKind.Unspecified);

            value = dateTime.ToIso8601String();

            Assert.That(value, Is.EqualTo("20101015T123025"));
        }

        [Test]
        public void TestToUtcIso8601String()
        {
            var dateTime = new DateTime(2010, 10, 15, 12, 30, 25, DateTimeKind.Utc);

            var value = dateTime.ToIso8601String();

            Assert.That(value, Is.EqualTo("20101015T123025Z"));
        }

        [Test]
        public void TestToUnixTimestamp()
        {
            var time = new DateTime(2011, 1, 1).ToUnixTimestamp();

            Assert.That(time, Is.EqualTo(1293840000.0d));
        }

        [Test]
        public void TestTimeRemaningWhenExceptionIsThrown()
        {
            var start = DateTime.Now.AddMinutes(-5);

            var result = start.TimeRemaining(0, 100);

            Assert.That(result, Is.EqualTo("unknown"));
        }

        [Test]
        public void TestTimeRemaningWhenTimeRemaningIsInSeconds()
        {
            var start = DateTime.UtcNow.AddMinutes(-5);

            var result = start.TimeRemaining(90, 100);

            Assert.That(result, Is.EqualTo("33s"));
        }

        [Test]
        public void TestTimeRemaningWhenTimeRemaningIsInMinutes()
        {
            var start = DateTime.UtcNow.AddMinutes(-5);

            var result = start.TimeRemaining(50, 100);

            Assert.That(result, Is.EqualTo("5m 0s"));
        }

        [Test]
        public void TestTimeRemaningWhenTimeRemaningIsInHours()
        {
            var start = DateTime.UtcNow.AddMinutes(-5);

            var result = start.TimeRemaining(1, 100);

            Assert.That(result, Is.EqualTo("8h 15m 0s"));
        }
    }
}
