using System;

namespace Sugar
{
    public static class ToDoubleExtension
    {
        public static double ToDouble(this string value)
        {
            return value.ToDouble(0);
        }

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
    }
}
