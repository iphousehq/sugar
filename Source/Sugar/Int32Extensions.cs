namespace Sugar
{
    /// <summary>
    /// Extension methods for integers.
    /// </summary>
    public static class Int32Extensions
    {
        /// <summary>
        /// Convert string to integer
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int AsInt32(this string value)
        {
            return value.AsInt32(0);
        }

        /// <summary>
        /// Convert string to integer with a default if the string is empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="default">The @default.</param>
        /// <returns></returns>
        public static int AsInt32(this string value, int @default)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                int.TryParse(value, out @default);
            }

            return @default;
        }

        /// <summary>
        /// Adds an ordinal.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string AddOrdinal(this int value)
        {
            var result = value.ToString();

            if(value > 0)
            {
                switch(value % 100)
                {
                    case 11: case 12: case 13: result += "th"; break;

                    default:
                        switch(value % 10)
                        {
                            case 1: result += "st"; break;
                            case 2: result += "nd"; break;
                            case 3: result += "rd"; break;
                            default: result += "th"; break;
                        }
                    break;
                }
            }

            return result;
        }
    }
}
