using System;
using System.Collections.Generic;

namespace Sugar
{
    /// <summary>
    /// <see cref="double"/> extensions methods.
    /// </summary>
    public static class ToDoubleExtension
    {
        /// <summary>
        /// Parse a string to a double
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return value.ToDouble(0);
        }

        /// <summary>
        /// Parse a string to a double
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static double ToDouble(this string value, double @default)
        {
            var result = @default;

            if (!string.IsNullOrEmpty(value))
            {
                double temp;

                if (double.TryParse(value, out temp))
                {
                    result = Convert.ToDouble(temp);
                }
            }

            return result;
        }

        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToRadians(this double value)
        {
            return (Math.PI / 180.0) * value;
        }

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static double ToDegrees(this double value)
        {
            return (180.0 / Math.PI) * value;
        }

		/// <summary>
        /// Gets the date time from this Unix timestamp.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        public static DateTime FromUnixTimestamp(this double time)
        {
            //create a new DateTime value based on the Unix Epoch
            var converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);

            //add the timestamp to the value
            var newDateTime = converted.AddSeconds(time);

            //return the value in string format
            return newDateTime.ToLocalTime();
        }

        /// <summary>
        /// Formats the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="useText">if set to <c>true</c> [use text].</param>
        /// <returns></returns>
        public static string Format(this double value, bool useText = false)
        {
            var bands = new List<dynamic>
            {
                new
                {
                    Name = "thousand",
                    Value = Math.Pow(10, 5),
                    RoundingValue = Math.Pow(10, 3),
                    DecimalPlaces = 0
                },
                new
                {
                    Name = "million",
                    Value = Math.Pow(10, 6),
                    RoundingValue = Math.Pow(10, 6),
                    DecimalPlaces = 1
                },
                new
                {
                    Name = "billion",
                    Value = Math.Pow(10, 9),
                    RoundingValue = Math.Pow(10, 9),
                    DecimalPlaces = 1
                }
            };
            
            
            var number = Math.Abs(value);

            const string format = "{0}{1}";

            var numberPart = Math.Round(value, 2);

            var wordPart = "";

            if(useText)
            {
                for (var i = 0; i < bands.Count; i++)
                {
                    if (number >= bands[i].Value)
                    {
                        if (i + 1 < bands.Count)
                        {
                            if (number < bands[i + 1].Value)
                            {
                                numberPart = Math.Round((number / bands[i].RoundingValue), bands[i].DecimalPlaces);

                                wordPart = " " + bands[i].Name;

                                break;
                            }
                        }
                        else
                        {
                            numberPart = Math.Round((number / bands[i].Value), bands[i].DecimalPlaces);

                            wordPart = " " + bands[i].Name;

                            break;
                        }
                    }
                }
            }

            return string.Format(format, numberPart.ToString("###,###,###,##0.##"), wordPart);
        }
    }
}
