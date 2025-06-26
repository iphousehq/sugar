using System;
using System.Collections.Generic;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="DateTime"/> class.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Changes the <see cref="DateTimeKind"/> of the specified <see cref="dateTime"/> without changing the time offset.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="kind">The kind.</param>
        /// <returns>Retruns a new instance of date time.</returns>
        public static DateTime SpecifyKind(this DateTime dateTime, DateTimeKind kind)
        {
            return DateTime.SpecifyKind(dateTime, kind);
        }

        /// <summary>
        /// Changes the <see cref="DateTimeKind"/> of the specified <see cref="dateTime"/> without changing the time offset.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <param name="kind">The kind.</param>
        /// <returns>Retruns a new instance of date time.</returns>
        public static DateTime? SpecifyKind(this DateTime? dateTime, DateTimeKind kind)
        {
            if (dateTime.HasValue)
            {
                return DateTime.SpecifyKind(dateTime.Value, kind);
            }

            return null;
        }

        /// <summary>
        /// Describes this nullable <see cref="DateTime"/> value by building a human readable string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string Humanise(this DateTime? dateTime)
        {
            return dateTime.HasValue
                       ? dateTime.Value.Humanise()
                       : DateTime.MinValue.Humanise();
        }

        /// <summary>
        /// Describes this <see cref="DateTime"/> value by building a human readable string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string Humanise(this DateTime dateTime)
        {
            var value = "never";

            var now = DateTime.UtcNow;

            var timeElapsed = HumaniseTimeBetweenTwoDates(dateTime, now);

            if (timeElapsed != "never")
            {
                value = dateTime < now ? $"{timeElapsed} ago" : $"in {timeElapsed}";
            }

            return value;
        }

        /// <summary>
        /// Describes the time between this <see cref="DateTime"/> and another
        /// </summary>
        /// <param name="first">The first datetime.</param>
        /// <param name="second">The second datetime.</param>
        /// <returns></returns>
        public static string HumaniseTimeBetweenTwoDates(this DateTime first, DateTime second)
        {
            var value = string.Empty;

            var secondsAgo = Math.Abs(first.Subtract(second).TotalSeconds);

            var daysAgo = Math.Abs(first.Subtract(second).TotalDays);

            if (daysAgo > 3650) value = "never";

            if (daysAgo > 366 && daysAgo <= 3650) value = "over a year";

            if (daysAgo <= 366) value = "a year";

            if (daysAgo < 365) value = $"about {Convert.ToInt32(daysAgo / 30)} months";

            if (daysAgo < 45) value = "about a month";

            if (daysAgo < 28) value = $"{Convert.ToInt32(daysAgo)} days";

            if (secondsAgo < 172800) value = "a day";

            if (secondsAgo < 86400) value = $"{Convert.ToInt32(secondsAgo / 3600)} hours";

            if (secondsAgo < 7200) value = "an hour";

            if (secondsAgo < 3600) value = $"{Convert.ToInt32(secondsAgo / 60)} minutes";

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
        /// Gets the start of the week given by this date.
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
        /// Gets the end of the week given by this date.
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
        /// Gets the last day of the month given by this date.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static DateTime EndOfMonth(this DateTime dt)
        {
            var numberOfDays = DateTime.DaysInMonth(dt.Year, dt.Month);

            return new DateTime(dt.Year, dt.Month, numberOfDays, 23, 59, 59);
        }

        /// <summary>
        /// Gets a list of dates going back a set number of days from this date.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="howManyDays">The how many days.</param>
        /// <returns></returns>
        public static IList<DateTime> GetPreviousDays(this DateTime value, int howManyDays)
        {
            var results = new List<DateTime>();

            for (var i = 0; i < howManyDays; i++)
            {
                results.Add(value.AddDays(-i).Date);
            }

            return results;
        }

        /// <summary>
        /// Constrain this date to within given bounds. If the date is not within the bounds the current date is returned.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <returns></returns>
        public static DateTime InBounds(this DateTime value, DateTime lower, DateTime upper)
        {
            return value.InBounds(lower, upper, DateTime.UtcNow);
        }

        /// <summary>
        /// Constrain this date to within given bounds. If the date is not within the bounds a default date is returned.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="lower">The lower.</param>
        /// <param name="upper">The upper.</param>
        /// <param name="default">The default value to use if the value is not in range.</param>
        /// <returns></returns>
        public static DateTime InBounds(this DateTime value, DateTime lower, DateTime upper, DateTime @default)
        {
            var result = value;

            // Too far in the past
            if (result < lower)
            {
                result = @default;
            }

            // Too far in the future
            if (result > upper)
            {
                result = @default;
            }

            return result;
        }

        /// <summary>
        /// Works out the number of month between this date instance and the one given as a parameter.
        /// </summary>
        /// <param name="lValue">This intance of a date time.</param>
        /// <param name="rValue">The r value.</param>
        /// <returns></returns>
        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return lValue.Month - rValue.Month + 12 * (lValue.Year - rValue.Year);
        }

        /// <summary>
        /// Get a string that describes the time remaining using this date as the start and given a total time in seconds and the time taken in seconds.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="progress">The progress.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public static string TimeRemaining(this DateTime start, int progress, int total)
        {
            var result = string.Empty;

            try
            {
                var timeTaken = (DateTime.UtcNow - start).TotalSeconds;

                var remaining = TimeSpan.FromSeconds(timeTaken / progress * total - timeTaken);

                if (remaining.Days > 0)
                {
                    result += $"{remaining.Days}d ";
                }

                if (remaining.Hours > 0)
                {
                    result += $"{remaining.Hours}h ";
                }

                if (remaining.Minutes > 0)
                {
                    result += $"{remaining.Minutes}m ";
                }

                result += $"{remaining.Seconds}s";
            }
            catch (Exception)
            {
                result = "unknown";
            }

            return result;
        }

        /// <summary>
        /// Converts this date to an ISO 8601 date string.
        /// </summary>
        /// <remarks>
        /// If <see cref="DateTimeKind"/> is unspecified, the time will be assumed to be local time.
        /// </remarks>
        /// <param name="datetime">The datetime.</param>
        /// <returns></returns>
        public static string ToIso8601String(this DateTime datetime)
        {
            if (datetime.Kind == DateTimeKind.Utc)
            {
                return datetime.ToString("yyyy-MM-ddTHH:mm:ssZ");
            }

            return datetime.ToString("yyyy-MM-ddTHH:mm:ss");
        }

        /// <summary>
        /// Converts this date to an ISO 8601 date string.
        /// </summary>
        /// <remarks>
        /// If <see cref="DateTimeKind"/> is unspecified, the time will be assumed to be local time.
        /// </remarks>
        /// <param name="datetime">The datetime.</param>
        /// <returns></returns>
        public static string ToIso8601String(this DateTime? datetime)
        {
            if (datetime.HasValue)
            {
                return ToIso8601String(datetime.Value);
            }

            return string.Empty;
        }

        /// <summary>
        /// Converts this <see cref="DateTime"/> to a new <see cref="DateTime"/> specified by the time zone offset value
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
        /// Coverts this date to a string with an ordinal for the day.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string ToStringWithOrdinal(this DateTime dt)
        {
            return $"{dt.Day.AddOrdinal()} {dt:MMMM yyyy}";
        }

        /// <summary>
        /// Converts this date to a Unix timestamp.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static double ToUnixTimestamp(this DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var diff = date - origin;

            return Math.Floor(diff.TotalSeconds);
        }
    }
}
