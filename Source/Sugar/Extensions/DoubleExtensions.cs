using System;

namespace Sugar.Extensions
{
    /// <summary>
    /// <see cref="double"/> extensions methods.
    /// </summary>
    public static class ToDoubleExtension
    {
        /// <summary>
        /// Converts this double value from a UNIX timestamp to a <see cref="DateTime"/>
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(this double time)
        {
            var converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            var newDateTime = converted.AddSeconds(time);

            return newDateTime.ToLocalTime();
        }

        /// <summary>
        /// Describes this double value by building a human readable string
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="useText">if set to <c>true</c> [use text].</param>
        /// <returns></returns>
        public static string Humanise(this double value, bool useText = false)
        {
            var number = Math.Abs(value);

            var numberPart = Math.Round(value, 2);
            var wordPart = string.Empty;

            if (useText)
            {
                if (number >= Math.Pow(10, 9)) // Greater than a billion
                {
                    numberPart = Math.Round(number / Math.Pow(10, 9), 1);
                    wordPart = " billion";
                }
                else if (number >= Math.Pow(10, 6)) // Greater than a million
                {
                    numberPart = Math.Round(number / Math.Pow(10, 6), 1);
                    wordPart = " million";
                }
                else if (number >= Math.Pow(10, 5)) // Greater than a thousand
                {
                    numberPart = Math.Round(number / Math.Pow(10, 3), 0);
                    wordPart = " thousand";
                }
            }

            return $"{numberPart.ToString("###,###,###,##0.##")}{wordPart}";
        }

        /// <summary>
        /// Convert this double value from degrees to radians.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToRadians(this double value)
        {
            return (Math.PI / 180.0) * value;
        }

        /// <summary>
        /// Convert this double value from radians to degrees.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToDegrees(this double value)
        {
            return (180.0 / Math.PI) * value;
        }
    }
}
