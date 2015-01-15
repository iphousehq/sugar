using System.Collections.Generic;

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

        /// <summary>
        /// Gets the percent of this value out of the given total.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="total">The total.</param>
        /// <returns></returns>
        public static double PercentOf(this int value, int total)
        {
            return (100 / (double)total) * value;
        }

        /// <summary>
        /// Removes the values given values from this instance.
        /// </summary>
        /// <param name="values">The list of integers to be processed.</param>
        /// <param name="toRemove">The list of integers to be removed.</param>
        /// <returns></returns>
        public static IList<int> RemoveValues(this IList<int> values, IList<int> toRemove)
        {
            var result = new List<int>();

            for (var i = values.Count - 1; i >= 0; i--)
            {
                if (!toRemove.Contains(values[i]))
                {
                    result.Add(values[i]);
                }
            }

            return result;
        }

        /// <summary>
        /// Return an IEnumerable of int from the start point to the stopPoint
        /// </summary>
        /// <param name="startPoint">The start point.</param>
        /// <param name="stopPoint">The stop point.</param>
        /// <returns></returns>
        /// <remarks>
        /// Can be handy to emulate a plain for loop when rendering a view.
        /// </remarks>
        public static IEnumerable<int> Till(this int startPoint, int stopPoint)
        {
            if (startPoint < stopPoint)
                for (var i = startPoint; i < stopPoint; i++)
                    yield return i;
            else
                for (var i = startPoint; i < stopPoint; i--)
                    yield return i;
        }
    }
}
