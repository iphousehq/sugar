using System;

namespace Sugar
{
    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> class.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Converts <see cref="TimeSpan"/> objects to a string.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns></returns>
        public static string ToReadableString(this TimeSpan timespan)
        {
            Func<int, string, string> section =
                (span, label) => span > 0
                                     ? string.Format("{0} {1}, ", span, span == 1 ? label : label + "s")
                                     : string.Empty;


            var formatted = string.Format("{0}{1}{2}{3}",
                                          section(timespan.Days, "day"),
                                          section(timespan.Hours, "hour"),
                                          section(timespan.Minutes, "minute"),
                                          section(timespan.Seconds, "second"));

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted) && timespan.Milliseconds > 0) formatted = "Less than a second";

            return formatted;
        }
    }
}