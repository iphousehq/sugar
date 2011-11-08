﻿using System;
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
        /// Examples: 2009-10-08 08:22:02Z, 20091008T082202
        /// </summary>
        /// <param name="value">The date time in the ISO 8601 format.</param>
        /// <returns></returns>
        public static DateTime ToDateTimeFromIso8601(this string value)
        {
            var time =
                DateTime.ParseExact(
                    value,
                    new[] { "s", "u", "yyyyMMddTHHmmss" },
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None);

            return time;
        }

        /// <summary>
        /// Tries to date time from iso8601 (e.g. 20100130T235959).
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="time">The time in the ISO 8601 format.</param>
        /// <returns></returns>
        public static bool TryToDateTimeFromIso8601(this string value, out DateTime time)
        {
            return
                DateTime.TryParseExact(
                    value,
                    new[] { "s", "u", "yyyyMMddTHHmmss" },
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out time);
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> objects to a string representing the time passed since
        /// the current time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToTimeAgo(this DateTime? dateTime)
        {
            return dateTime.HasValue ? dateTime.Value.ToTimeAgo() : "Never";
        }

        /// <summary>
        /// Converts <see cref="DateTime"/> objects to a string representing the time passed since
        /// the current time.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns></returns>
        public static string ToTimeAgo(this DateTime dateTime)
        {
            var value = string.Empty;

            var secondsAgo = dateTime.Subtract(DateTime.Now).TotalSeconds * -1;

            var daysAgo = dateTime.Subtract(DateTime.Now).TotalDays * -1;

            if (daysAgo >= 365) value = "over a year ago";

            if (daysAgo > 3650) value = "never";

            if (daysAgo < 365) value = "about " + Convert.ToInt32(daysAgo / 30) + " months ago";

            if (daysAgo < 31) value = Convert.ToInt32(daysAgo) + " days ago";

            if (secondsAgo < 172800) value = "a day ago";

            if (secondsAgo < 86400) value = Convert.ToInt32(secondsAgo / 3600) + " hours ago";

            if (secondsAgo < 7200) value = "an hour ago";

            if (secondsAgo < 7200) value = "an hour ago";

            if (secondsAgo < 3600) value = Convert.ToInt32(secondsAgo / 60) + " minutes ago";

            if (secondsAgo < 300) value = "a few minutes ago";

            if (secondsAgo < 60) value = "a few seconds ago";

            return value;
        }
    }
}