﻿using System;
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
    }
}
