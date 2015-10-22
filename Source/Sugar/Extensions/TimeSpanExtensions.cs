using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> class.
    /// </summary>
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Gets the number of complete months (approximated to 30.436875 days per month) in this timespan.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns></returns>
        public static int Months(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 30.436875);
        }

        /// <summary>
        /// Gets the number of complete years (approximated to 365.2425 days per year) in this timespan.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <returns></returns>
        public static int Years(this TimeSpan timespan)
        {
            return (int)(timespan.Days / 365.2425);
        }

        private static string FormatSection(int span, TimeSpanPart part)
        {
            var section = string.Empty;

            if (span > 0)
            {
                var partString = part.ToString().ToLower();

                if (span > 1)
                {
                    partString += "s";
                }

                section = $"{span} {partString}";
            }

            return section;
        }

        /// <summary>
        /// Converts this timespan to a human readable string.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <param name="parts">The parts (flagable).</param>
        /// <returns>
        /// Always returns a value (empty when no ticks) to allow method chaining.
        /// </returns>
        public static string Humanise(this TimeSpan timespan, TimeSpanPart parts = TimeSpanPart.Day | TimeSpanPart.Hour | TimeSpanPart.Minute | TimeSpanPart.Second)
        {
            var result = string.Empty;

            if (timespan.Ticks > 0)
            {
                var formattedSections = new List<string>();

                if (parts.HasFlag(TimeSpanPart.Day))
                    formattedSections.Add(FormatSection(timespan.Days, TimeSpanPart.Day));

                if (parts.HasFlag(TimeSpanPart.Hour))
                    formattedSections.Add(FormatSection(timespan.Hours, TimeSpanPart.Hour));

                if (parts.HasFlag(TimeSpanPart.Minute))
                    formattedSections.Add(FormatSection(timespan.Minutes, TimeSpanPart.Minute));

                if (parts.HasFlag(TimeSpanPart.Second))
                    formattedSections.Add(FormatSection(timespan.Seconds, TimeSpanPart.Second));

                result = string.Join(", ", formattedSections.Where(s => !string.IsNullOrEmpty(s)));

                if (string.IsNullOrEmpty(result))
                {
                    if (parts == TimeSpanPart.Day)
                    {
                        result = "Less than a day";
                    }
                    else if (parts == TimeSpanPart.Minute)
                    {
                        result = "Less than a minute";
                    }
                    else if (parts.HasFlag(TimeSpanPart.Second))
                    {
                        result = "Less than a second";
                    }
                }
            }

            return result;
        }
    }
}