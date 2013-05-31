using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Extension methods for the <see cref="DateTime"/> class.
    /// </summary>
    public static class ToDateTimeExtension
    {
        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>SqlDateTime.MinValue when it fails to Parse the DateTime</returns>
        public static DateTime ToDateTime(this string value)
        {
            return value.ToDateTime(SqlDateTime.MinValue.Value);
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default value.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, DateTime @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                if (!DateTime.TryParse(value, out result))
                {
                    result = @default;
                }
            }

            return result;
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object using the specified format.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <returns>SqlDateTime.MinValue when it fails to Parse the DateTime</returns>
        public static DateTime ToDateTime(this string value, string format)
        {
            return value.ToDateTime(format, SqlDateTime.MinValue.Value);
        }

        /// <summary>
        /// Converts this string into a <see cref="DateTime"/> object using the specified format.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="format">The format.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value, string format, DateTime @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                if (!DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    result = @default;
                }
            }

            return result;
        }

        /// <summary>
        /// Parses a datetime string formatted using the ISO 8601 format.
        /// Examples: 2009-10-08T08:22:02Z, 20091008T082202
        /// </summary>
        /// <param name="value">The date time in the ISO 8601 format.</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromIso8601(this string value)
        {
            var formats = new[]
                              {
                                  "yyyy-MM-ddTHH:mm:ssK",
                                  "yyyyMMddTHHmmssK",

                                  "yyyy-MM-ddTHH:mm:ss",
                                  "yyyyMMddTHHmmss",

                                  "yyyy-MM-ddTHH:mmK",
                                  "yyyyMMddTHHmmK",

                                  "yyyy-MM-ddTHH:mm",
                                  "yyyyMMddTHHmm",

                                  "yyyy-MM-ddTHHK",
                                  "yyyyMMddTHHK",

                                  "yyyy-MM-ddTHH",
                                  "yyyyMMddTHH",

                                  "yyyy-MM-dd",
                                  "yyyyMMdd"
                              };


            foreach (var format in formats)
            {
                DateTime result;

                if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
                {
                    return result;
                }
            }

            throw new ApplicationException("The given date-time string was not in an ISO8061 format.");
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> objects to a string representing the time elapsed or time until the given date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToHumanReadableString(this DateTime? dateTime)
        {
            return dateTime.HasValue
                       ? dateTime.Value.ToHumanReadableString()
                       : DateTime.MinValue.ToHumanReadableString();
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> objects to a string representing the time elapsed or time until the given date time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToHumanReadableString(this DateTime dateTime)
        {
            var value = "never";

            var now = DateTime.Now;

            var timeElapsed = ToAbsHumanReadableString(dateTime, now);

            if (timeElapsed != "never")
            {
                value = dateTime < now
                    ? string.Format("{0} ago", timeElapsed)
                    : string.Format("in {0}", timeElapsed);
            }

            return value;
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> objects to a string representing the time between it and another <see cref="DateTime"/>.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static string ToAbsHumanReadableString(this DateTime first, DateTime second)
        {
            var value = string.Empty;

            var secondsAgo = Math.Abs(first.Subtract(second).TotalSeconds);

            var daysAgo = Math.Abs(first.Subtract(second).TotalDays);

            if (daysAgo > 3650) value = "never";

            if (daysAgo > 366 && daysAgo <= 3650) value = "over a year";

            if (daysAgo <= 366) value = "a year";

            if (daysAgo < 365) value = "about " + Convert.ToInt32(daysAgo / 30) + " months";

            if (daysAgo < 45) value = "about a month";

            if (daysAgo < 28) value = Convert.ToInt32(daysAgo) + " days";

            if (secondsAgo < 172800) value = "a day";

            if (secondsAgo < 86400) value = Convert.ToInt32(secondsAgo / 3600) + " hours";

            if (secondsAgo < 7200) value = "an hour";

            if (secondsAgo < 3600) value = Convert.ToInt32(secondsAgo / 60) + " minutes";

            if (secondsAgo < 300) value = "a few minutes";

            if (secondsAgo < 60) value = "a few seconds";

            return value;
        }

        /// <summary>
        /// Gets the a list of dates representing months between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> MonthsUntil(this DateTime from, DateTime until)
        {
            var results = new List<DateTime>();

            var current = new DateTime(from.Year, from.Month, 1);
            var end = new DateTime(until.Year, until.Month, 1);

            if (current > end)
            {
                return results;
            }

            while (current <= end)
            {
                results.Add(current);

                current = current.AddMonths(1);
            }

            return results;
        }

        /// <summary>
        /// Gets the a list of dates representing weeks between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> WeeksUntil(this DateTime from, DateTime until)
        {
            var results = new List<DateTime>();

            var current = new DateTime(from.Year, from.Month, from.Day).StartOfWeek(DayOfWeek.Monday);
            var end = new DateTime(until.Year, until.Month, until.Day).StartOfWeek(DayOfWeek.Monday);

            if (current > end)
            {
                return results;
            }

            while (current <= end)
            {
                results.Add(current);

                current = current.AddDays(7);
            }

            return results;
        }

        /// <summary>
        /// Gets the a list of dates representing weeks between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <param name="weekStart">The week start.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> WeeksUntil(this DateTime from, DateTime until, DayOfWeek weekStart)
        {
            var results = new List<DateTime>();

            var current = new DateTime(from.Year, from.Month, from.Day).StartOfWeek(weekStart);
            var end = new DateTime(until.Year, until.Month, until.Day).StartOfWeek(weekStart);

            if (current > end)
            {
                return results;
            }

            while (current <= end)
            {
                results.Add(current);

                current = current.AddDays(7);
            }

            return results;
        }

        /// <summary>
        /// Gets the a list of dates representing days between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> DaysUntil(this DateTime from, DateTime until)
        {
            var results = new List<DateTime>();

            var current = new DateTime(from.Year, from.Month, from.Day);
            var end = new DateTime(until.Year, until.Month, until.Day);

            if (current > end)
            {
                return results;
            }

            while (current <= end)
            {
                results.Add(current);

                current = current.AddDays(1);
            }

            return results;
        }

        /// <summary>
        /// Gets the start of the week given by the date time.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="startOfWeek">The start of week.</param>
        /// <returns></returns>
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var takeDays = dt.DayOfWeek - startOfWeek;

            if (startOfWeek == DayOfWeek.Monday && dt.DayOfWeek == DayOfWeek.Sunday)
            {
                takeDays = 6;
            }

            return dt.AddDays(-takeDays);
        }

        /// <summary>
        /// Gets the last day of the month given by the date time.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt)
        {
            var numberOfDays = DateTime.DaysInMonth(dt.Year, dt.Month);

            return new DateTime(dt.Year, dt.Month, numberOfDays, 23, 59, 59);
        }

        /// <summary>
        /// To the string with ordinal.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string ToStringWithOrdinal(this DateTime dt)
        {
            return string.Format("{0} {1}", dt.Day.AddOrdinal(), dt.ToString("MMMM yyyy"));
        }
    }
}
