using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Sugar
{
    [TestFixture]
    public class ToDateTimeExtensionTest
    {
        [Test]
        public void TestToDateValidString()
        {
            var result = "20/05/2010 15:10:50".ToDateTime();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(05, result.Month);
            Assert.AreEqual(20, result.Day);
            Assert.AreEqual(15, result.Hour);
            Assert.AreEqual(10, result.Minute);
            Assert.AreEqual(50, result.Second);
        }

        [Test]
        public void TestToDateStringInvalidValueDefaultToSqlMinTime()
        {
            var result = "bonjour".ToDateTime();

            Assert.AreEqual(1753, result.Year);
        }

        [Test]
        public void TestToDateTimeWithCustomFormat()
        {
            var result = "23-45-59 2011_01_30".ToDateTime("HH-mm-ss yyyy_MM_dd");

            Assert.AreEqual(2011, result.Year);
            Assert.AreEqual(1, result.Month);
            Assert.AreEqual(30, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(45, result.Minute);
            Assert.AreEqual(59, result.Second);
        }

        [Test]
        public void TestToDateTimeWithCustomFormatButIsInvalid()
        {
            var result = "bonjour".ToDateTime("HH-mm-ss yyyy_MM_dd");

            Assert.AreEqual(1753, result.Year);
        }

        [Test]
        public void TestToDateFromIso8601()
        {
            var result = "20101231T235955".ToDateTimeFromIso8601();

            Assert.AreEqual(2010, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
            Assert.AreEqual(23, result.Hour);
            Assert.AreEqual(59, result.Minute);
            Assert.AreEqual(55, result.Second);
        }

        [Test]
        public void TestTryParseDateTimeFromIso8601()
        {
            DateTime time;

            var result = "20101231T235955".TryToDateTimeFromIso8601(out time);

            Assert.IsTrue(result);

            Assert.AreEqual(2010, time.Year);
            Assert.AreEqual(12, time.Month);
            Assert.AreEqual(31, time.Day);
            Assert.AreEqual(23, time.Hour);
            Assert.AreEqual(59, time.Minute);
            Assert.AreEqual(55, time.Second);
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
            var results = new DateTime(2011, 1, 1).MonthsUntil(new DateTime(2011, 1, 1));

            Assert.AreEqual(1, results.Count());
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

            var results = new DateTime(2011, 12, 29).WeeksUntil(new DateTime(2012, 2, 7));

            Assert.AreEqual(expected.Count, results.Count());
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
                                   new DateTime(2012, 2, 1),
                                   new DateTime(2012, 2, 8),
                               };

            var results = new DateTime(2011, 12, 29).WeeksUntil(new DateTime(2012, 2, 7), DayOfWeek.Wednesday);

            Assert.AreEqual(expected.Count, results.Count());
            Assert.AreEqual(expected[0], results.ElementAt(0));
            Assert.AreEqual(expected[6], results.ElementAt(6));
        }

        [Test]
        public void TestWeeksUntilWeekStartFriday()
        {
            var expected = new List<DateTime>
                               {
                                   new DateTime(2011, 12, 30),
                                   new DateTime(2012, 1, 6),
                                   new DateTime(2012, 1, 13),
                                   new DateTime(2012, 1, 20),
                                   new DateTime(2012, 1, 27),
                                   new DateTime(2012, 2, 3),
                                   new DateTime(2012, 2, 10),
                               };

            var results = new DateTime(2011, 12, 29).WeeksUntil(new DateTime(2012, 2, 7), DayOfWeek.Friday);

            Assert.AreEqual(expected.Count, results.Count());
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

            var results = new DateTime(2011, 12, 26).WeeksUntil(new DateTime(2012, 3, 12));

            Assert.AreEqual(expected.Count, results.Count());
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
    }
}
