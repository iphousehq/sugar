using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IEnumerable{T}"/> objects.
    /// </summary>
    public static class GenericEnumerableExtensions
    {
        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="int"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, int> selector)
        {
            return enumerable.Distinct<T, int>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="long"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, long> selector)
        {
            return enumerable.Distinct<T, long>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="ulong"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, ulong> selector)
        {
            return enumerable.Distinct<T, ulong>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="double"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, double> selector)
        {
            return enumerable.Distinct<T, double>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="string"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, string> selector)
        {
            return enumerable.Distinct<T, string>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="bool"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, bool> selector)
        {
            return enumerable.Distinct<T, bool>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="char"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> enumerable, Func<T, char> selector)
        {
            return enumerable.Distinct<T, char>(selector);
        }

        /// <summary>
        /// Returns distinct elements from this enumerable
        /// </summary>
        /// <remarks>
        /// The elements are distinct based on the value of type <see cref="TPrim"/> given by the selector
        /// </remarks>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TPrim"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="selector">The selector.</param>
        /// <returns></returns>
        private static IEnumerable<T> Distinct<T, TPrim>(this IEnumerable<T> enumerable, Func<T, TPrim> selector) where TPrim : IComparable
        {
            var results = new Dictionary<TPrim, T>();

            foreach (var item in enumerable)
            {
                var value = selector(item);

                if (!results.ContainsKey(value))
                {
                    results.Add(value, item);
                }
            }

            return results.Values;
        }

        /// <summary>
        /// Performs the given action on each of the elements in this enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="each">The each.</param>
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> each)
        {
            foreach (var item in enumerable) each(item);
        }

        /// <summary>
        /// Returns a comma seperated value representation of this enumerable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="separator">The seperator.</param>
        /// <param name="lastSeparator">The last separator (is set to separator when null or empty).</param>
        /// <returns></returns>
        public static string ToCsv<T>(this IEnumerable<T> enumerable, string separator = ",", string lastSeparator = null)
        {
            var result = string.Empty;

            if (enumerable != null)
            {
                var builder = new StringBuilder();

                return enumerable.ToCsv(builder, separator, lastSeparator).ToString();
            }

            return result;
        }

        /// <summary>
        /// Appends CSV values represetning the <see cref="enumerable"/> to the provided <see cref="builder"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="builder">The string builder.</param>
        /// <param name="separator">The separator.</param>
        /// <param name="lastSeparator">The last separator.</param>
        /// <returns></returns>
        public static StringBuilder ToCsv<T>(this IEnumerable<T> enumerable, StringBuilder builder, string separator = ",", string lastSeparator = null)
        {
            if (enumerable != null)
            {
                var valuesList = enumerable.Select(v => Convert.ToString(v))
                    .Where(v => !string.IsNullOrEmpty(v))
                    .ToList();

                lastSeparator = !string.IsNullOrEmpty(lastSeparator) ? lastSeparator : separator;

                // Append to provided string builder (when set)
                builder = builder ?? new StringBuilder();

                for (var i = 0; i < valuesList.Count; i++)
                {
                    if (i > 0) // Skip first element for separator
                    {
                        builder.Append(i == valuesList.Count - 1 ? $"{lastSeparator}" : $"{separator}");
                    }

                    builder.Append(valuesList[i]);
                }
            }

            return builder;
        }
    }
}
