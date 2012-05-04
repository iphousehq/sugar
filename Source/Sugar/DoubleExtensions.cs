using System;

namespace Sugar
{
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

    }
}
