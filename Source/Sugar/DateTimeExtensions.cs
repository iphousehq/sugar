using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;

namespace Sugar
{
    /// <summary>
    /// Extension methods for the <see cref="DateTime"/> class.
    /// </summary>
    public static class ToDateTimeExtension
    {
        /// <summary>
        /// Converts the UTC value of the current DateTime object to the date and time specified by a time zone offset value.
        /// </summary>
        /// <param name="value">The value (it will be converted to UTC time).</param>
        /// <param name="offset">The time zone offset.</param>
        /// <returns>
        /// The local DateTime (UTC + time zone offset).
        /// </returns>
        public static DateTime ToOffset(this DateTime value, TimeSpan offset)
        {
            return value.ToUniversalTime().Add(offset);
        }

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
        /// Converts the ISO 8601 string to a DateTime.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static DateTime? ConvertFromIso8601(this string value)
        {
            DateTime? result = null;

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
                DateTime resultForFormat;

                if (DateTime.TryParseExact(value, format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out resultForFormat))
                {
                    result = resultForFormat;
                    break;
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
            var result = value.ConvertFromIso8601();

            if (result.HasValue)
            {
                return result.Value;
            }

            throw new ApplicationException("The given date-time string was not in an ISO8061 format.");
        }

        /// <summary>
        /// Tries to convert an ISO 8601 (e.g. 20100130T235959) value to a <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="time">The time in the ISO 8601 format.</param>
        /// <returns></returns>
        public static bool TryToDateTimeFromIso8601(this string value, out DateTime time)
        {
            var result = value.ConvertFromIso8601();

            time = new DateTime();

            if (result.HasValue)
            {
                time = result.Value;
                return true;
            }

            return false;
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

            var now = DateTime.UtcNow;

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
        /// Gets the a list of dates representing time between two dates.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="end">The end.</param>
        /// <param name="alterFunc">The alter func.</param>
        /// <returns></returns>
        private static IEnumerable<DateTime> TimeUntil(this DateTime current, DateTime end, Func<DateTime, DateTime> alterFunc)
        {
            var results = new List<DateTime>();

            if (current > end)
            {
                return results;
            }

            while (current <= end)
            {
                results.Add(current);

                current = alterFunc(current);
            }

            return results;
        }

        /// <summary>
        /// Gets the a list of dates representing months between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> MonthsUntil(this DateTime from, DateTime until)
        {
            var current = new DateTime(from.Year, from.Month, 1);
            var end = new DateTime(until.Year, until.Month, 1);

            return TimeUntil(current, end, d => d.AddMonths(1));
        }

        /// <summary>
        /// Gets the a list of dates representing weeks between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> WeeksUntil(this DateTime from, DateTime until)
        {
            var current = from.Date.StartOfWeek(DayOfWeek.Monday);
            var end = until.Date.StartOfWeek(DayOfWeek.Monday);

            return TimeUntil(current, end, d => d.AddDays(7));
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
            var current = from.Date.StartOfWeek(weekStart);
            var end = until.Date.StartOfWeek(weekStart);

            return TimeUntil(current, end, d => d.AddDays(7));
        }

        /// <summary>
        /// Gets the a list of dates representing days between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> DaysUntil(this DateTime from, DateTime until)
        {
            var current = from.Date;
            var end = until.Date;

            return TimeUntil(current, end, d => d.AddDays(1));
        }

        /// <summary>
        /// Gets the a list of dates representing hours between two dates.
        /// </summary>
        /// <param name="from">From.</param>
        /// <param name="until">The until.</param>
        /// <returns></returns>
        public static IEnumerable<DateTime> HoursUntil(this DateTime from, DateTime until)
        {
            return TimeUntil(from, until, d => d.AddHours(1));
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

            if (takeDays < 0)
            {
                takeDays = 7 - Math.Abs(takeDays);
            }

            return dt.AddDays(-takeDays);
        }

        /// <summary>
        /// Gets the end of the week given by the date time.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <param name="startOfWeek">The start of week.</param>
        /// <returns></returns>
        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            var takeDays = dt.DayOfWeek - startOfWeek;

            if (takeDays >= 0)
            {
                takeDays = 7 - takeDays;
            }

            return dt.AddDays(Math.Abs(takeDays) - 1);
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
