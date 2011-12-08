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
        public void TesDaysUntil()
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
    }
}
