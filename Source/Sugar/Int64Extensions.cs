using System;

namespace Sugar
{
    /// <summary>
    /// Extension methods for long numbers (Int64)
    /// </summary>
    public static class Int64Extensions
    {
        /// <summary>
        /// Convert string to integer
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static long AsInt64(this string value)
        {
            return value.AsInt64(0);
        }

        /// <summary>
        /// Convert string to integer with a default if the string is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static long AsInt64(this string value, long @default)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                Int64.TryParse(value, out @default);
            }

            return @default;
        }
    }
}