using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sugar.Extensions
{
    [TestFixture]
    public class ToDateTimeExtensionTest
    {
        [Test]
        public void TestToOffsetFromUtc()
        {
            var now = new DateTime(2014, 4, 11, 8, 2, 23, DateTimeKind.Utc);

            var offset = now.ToOffset(new TimeSpan(1, 30, 0));

            Assert.AreEqual(new DateTime(2014, 4, 11, 9, 32, 23), offset);
        }

        /// <summary>
        /// This test will fail on any machine that is not UTC
        /// </summary>
        [Test]
        public void TestToOffsetFromLocal()
        {
            var now = new DateTime(2014, 4, 11, 8, 2, 23, DateTimeKind.Local);

            var offset = now.ToOffset(new TimeSpan(1, 30, 0));

            Assert.AreEqual(new DateTime(2014, 4, 11, 9, 32, 23), offset);
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

            Assert.AreEqual(expected.Count, results.Count());
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

            Assert.AreEqual(expected.Count, results.Count());
        }

        [Test]
        public void TestMonthsUntilBoundsAreInCorrect()
        {
            var results = new DateTime(2011, 2, 1).MonthsUntil(new DateTime(2011, 1, 1));

            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void TestMonthsUntilSameMonth()
        {
            var results = new DateTime(2011, 1, 1).MonthsUntil(new DateTime(2011, 1, 1)).ToList();

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(new DateTime(2011, 1, 1), results.First());
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

            Assert.AreEqual(expected.Count, results.Count());
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

            Assert.AreEqual(expected.Count, results.Count);
            Assert.AreEqual(expected[0], results.ElementAt(0));
            Assert.AreEqual(expected[6], results.ElementAt(6));
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

            Assert.AreEqual(expected.Count, results.Count);
            Assert.AreEqual(expected[0], results.ElementAt(0));
            Assert.AreEqual(expected[5], results.ElementAt(5));
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

            Assert.AreEqual(expected.Count, results.Count);
            Assert.AreEqual(expected[0], results.ElementAt(0));
            Assert.AreEqual(expected[6], results.ElementAt(6));
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

            Assert.AreEqual(expected.Count, results.Count);
            Assert.AreEqual(expected[0], results.ElementAt(0));
            Assert.AreEqual(expected[9], results.ElementAt(9));
            Assert.AreEqual(expected[10], results.ElementAt(10));
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

            Assert.AreEqual(expected.Count, results.Count);
            Assert.AreEqual(expected[0], results.ElementAt(0));
            Assert.AreEqual(expected[9], results.ElementAt(9));
            Assert.AreEqual(expected[10], results.ElementAt(10));
        }

        [Test]
        public void TestStartOfWeek()
        {
            // Monday
            var result = new DateTime(2012, 1, 2).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result);

            // Tuesday
            var result2 = new DateTime(2012, 1, 3).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result2);

            // Wednesday
            var result3 = new DateTime(2012, 1, 4).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result3);

            // Thursday
            var result4 = new DateTime(2012, 1, 5).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result4);

            // Friday
            var result5 = new DateTime(2012, 1, 6).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result5);

            // Saturday
            var result6 = new DateTime(2012, 1, 7).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result6);

            // Sunday
            var result7 = new DateTime(2012, 1, 8).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 2), result7);

            // Sunday
            var result8 = new DateTime(2011, 12, 11).StartOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2011, 12, 5), result8);
        }

        [Test]
        public void TestEndOfWeek()
        {
            // Monday
            var result = new DateTime(2012, 1, 2).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result);

            // Tuesday
            var result2 = new DateTime(2012, 1, 3).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result2);

            // Wednesday
            var result3 = new DateTime(2012, 1, 4).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result3);

            // Thursday
            var result4 = new DateTime(2012, 1, 5).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result4);

            // Friday
            var result5 = new DateTime(2012, 1, 6).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result5);

            // Saturday
            var result6 = new DateTime(2012, 1, 7).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result6);

            // Sunday
            var result7 = new DateTime(2012, 1, 8).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2012, 1, 8), result7);

            // Sunday
            var result8 = new DateTime(2011, 12, 11).EndOfWeek(DayOfWeek.Monday);
            Assert.AreEqual(new DateTime(2011, 12, 11), result8);
        }

        [Test]
        public void TestEndOfMonth()
        {
            //beginning
            var result = new DateTime(2012, 1, 1).EndOfMonth();
            Assert.AreEqual(new DateTime(2012, 1, 31, 23, 59, 59), result);

            //middle
            result = new DateTime(2012, 1, 10).EndOfMonth();
            Assert.AreEqual(new DateTime(2012, 1, 31, 23, 59, 59), result);

            //end
            result = new DateTime(2012, 1, 31).EndOfMonth();
            Assert.AreEqual(new DateTime(2012, 1, 31, 23, 59, 59), result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsNever()
        {
            var dateOne = DateTime.MinValue;
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("never", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOverOneYear()
        {
            var dateOne = new DateTime(2010, 5, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("over a year", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneYear()
        {
            var dateOne = new DateTime(2011, 5, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("a year", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsAboutFourMonths()
        {
            var dateOne = new DateTime(2012, 1, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("about 4 months", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneMonth()
        {
            var dateOne = new DateTime(2012, 4, 10);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("about a month", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsFiveDays()
        {
            var dateOne = new DateTime(2012, 5, 5);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("5 days", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneDay()
        {
            var dateOne = new DateTime(2012, 5, 9);
            var dateTwo = new DateTime(2012, 5, 10);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("a day", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsFiveHours()
        {
            var dateOne = new DateTime(2012, 5, 10, 12, 30, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("5 hours", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsOneHour()
        {
            var dateOne = new DateTime(2012, 5, 10, 16, 30, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("an hour", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsTenMinutes()
        {
            var dateOne = new DateTime(2012, 5, 10, 17, 20, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("10 minutes", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsAFewMinutes()
        {
            var dateOne = new DateTime(2012, 5, 10, 17, 28, 30);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("a few minutes", result);
        }

        [Test]
        public void TestHumaniseTimeBetweenTwoDatesWhenResultIsAFewSeconds()
        {
            var dateOne = new DateTime(2012, 5, 10, 17, 30, 25);
            var dateTwo = new DateTime(2012, 5, 10, 17, 30, 30);

            var result = dateOne.HumaniseTimeBetweenTwoDates(dateTwo);

            Assert.AreEqual("a few seconds", result);
        }

        [Test]
        public void TestHumaniseWhenResultIsNull()
        {
            var result = ((DateTime?)null).Humanise();

            Assert.AreEqual("never", result);
        }

        [Test]
        public void TestHumaniseWhenResultIsNever()
        {
            var date = DateTime.MinValue;

            var result = date.Humanise();

            Assert.AreEqual("never", result);
        }

        [Test]
        public void TestHumaniseWhenResultIsInPast()
        {
            var date = DateTime.UtcNow.AddDays(-5);

            var result = date.Humanise();

            Assert.AreEqual("5 days ago", result);
        }

        [Test]
        public void TestHumaniseWhenResultIsInFuture()
        {
            var date = DateTime.UtcNow.AddDays(5);

            var result = date.Humanise();

            Assert.AreEqual("in 5 days", result);
        }

        [Test]
        public void TestToStringWithOrdinalTest()
        {
            var date = new DateTime(2001, 1, 1);

            var result = date.ToStringWithOrdinal();

            Assert.AreEqual("1st January 2001", result);
        }

        [Test]
        public void TestToListOfSingleDay()
        {
            var result = DateTime.UtcNow.GetPreviousDays(1);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(DateTime.UtcNow.Date, result[0]);
        }

        [Test]
        public void TestToListOfTwoDays()
        {
            var result = DateTime.UtcNow.GetPreviousDays(2);

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(DateTime.UtcNow.Date, result[0]);
            Assert.AreEqual(DateTime.UtcNow.AddDays(-1).Date, result[1]);
        }

        [Test]
        public void TestDateIsInBounds()
        {
            var result = new DateTime(2005, 1, 1).InBounds(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1));

            Assert.AreEqual(2005, result.Year);
        }

        [Test]
        public void TestDateIsLowerThanBounds()
        {
            var result = new DateTime(1999, 1, 1).InBounds(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1));

            Assert.AreEqual(DateTime.UtcNow.Year, result.Year);
        }

        [Test]
        public void TestDateIsHigherThanBounds()
        {
            var result = new DateTime(2015, 1, 1).InBounds(new DateTime(2000, 1, 1), new DateTime(2010, 1, 1));

            Assert.AreEqual(DateTime.UtcNow.Year, result.Year);
        }

        [Test]
        public void TestPositiveMonthDifference()
        {
            var now = new DateTime(2011, 06, 01);

            var result = now.MonthDifference(new DateTime(2011, 05, 1));

            Assert.AreEqual(1, result);
        }

        [Test]
        public void TestNegativeMonthDifference()
        {
            var now = new DateTime(2011, 06, 01);

            var result = now.MonthDifference(new DateTime(2011, 07, 1));

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestToIso8601String()
        {
            var dateTime = new DateTime(2010, 10, 15, 12, 30, 25);

            var value = dateTime.ToIso8601String();

            Assert.AreEqual("20101015T123025", value);
        }

        [Test]
        public void TestToUtcIso8601String()
        {
            var dateTime = new DateTime(2010, 10, 15, 12, 30, 25);

            var value = dateTime.ToIso8601String(true);

            Assert.AreEqual("20101015T123025Z", value);
        }

        [Test]
        public void TestToUnixTimestamp()
        {
            var time = new DateTime(2011, 1, 1).ToUnixTimestamp();

            Assert.AreEqual(1293840000.0d, time);
        }
    }
}
