using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Enumeration of the different parts of a <see cref="TimeSpan"/>
    /// </summary>
    [Flags]
    public enum TimeSpanPart
    {
        Day,
        Hour,
        Minute,
        Second
    }

    /// <summary>
    /// Extension methods for the <see cref="TimeSpan"/> class.
    /// </summary>
    public static class TimeSpanExtensions
    {
        private static string FormatSection(int span, TimeSpanPart part)
        {
            var section = string.Empty;

            if (span > 0)
            {
                var partString = part.ToString().ToLower();

                if (span > 1)
                {
                    partString +=  "s";
                }

                section = string.Format("{0} {1}", span, partString);
            }

            return section;
        }

        /// <summary>
        /// Converts <see cref="TimeSpan" /> objects to a string.
        /// </summary>
        /// <param name="timespan">The timespan.</param>
        /// <param name="parts">The parts.</param>
        /// <returns></returns>
        public static string ToReadableString(this TimeSpan timespan, TimeSpanPart parts = TimeSpanPart.Day | TimeSpanPart.Hour | TimeSpanPart.Minute | TimeSpanPart.Second)
        {
            var formattedSections = new List<string>();

            if(parts.HasFlag(TimeSpanPart.Day)) formattedSections.Add(FormatSection(timespan.Days, TimeSpanPart.Day));
            if(parts.HasFlag(TimeSpanPart.Hour)) formattedSections.Add(FormatSection(timespan.Hours, TimeSpanPart.Hour));
            if(parts.HasFlag(TimeSpanPart.Minute)) formattedSections.Add(FormatSection(timespan.Minutes, TimeSpanPart.Minute));
            if(parts.HasFlag(TimeSpanPart.Second)) formattedSections.Add(FormatSection(timespan.Seconds, TimeSpanPart.Second));

            var formatted = string.Join(", ", formattedSections.Where(s => !string.IsNullOrEmpty(s)));

            if (string.IsNullOrEmpty(formatted) && timespan.Milliseconds > 0 && parts.HasFlag(TimeSpanPart.Second)) formatted = "Less than a second";

            return formatted;
        }
    }
}