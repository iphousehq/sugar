using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> class.
    /// </summary>
    public static class TimeSpanExtensions
    {
        private static string FormatSection(int span, string label)
        {
            var section = string.Empty;

            if (span > 0)
            {
                if (span > 1)
                {
                    label += "s";
                }

                section = string.Format("{0} {1}", span, label);
            }

            return section;
        }

        /// <summary>
        /// Converts <see cref="TimeSpan"/> objects to a string.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns></returns>
        public static string ToReadableString(this TimeSpan timespan)
        {
            var formattedSections = new List<string>
                                        {
                                            FormatSection(timespan.Days, "day"),
                                            FormatSection(timespan.Hours, "hour"),
                                            FormatSection(timespan.Minutes, "minute"),
                                            FormatSection(timespan.Seconds, "second")
                                        }
                                        .Where(s => !string.IsNullOrEmpty(s));

            var formatted = string.Join(", ", formattedSections);

            if (string.IsNullOrEmpty(formatted)) formatted = "Less than a second";

            return formatted;
        }
    }
}