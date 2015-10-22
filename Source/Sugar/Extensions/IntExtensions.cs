namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="int"/>.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Adds an ordinal to this integer.
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

        /// <summary>
        /// Gets the percent of this integer out of the given total.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public static double PercentOf(this int value, int total)
        {
            return (100 / (double) total) * value;
        }
    }
}
