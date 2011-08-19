using System.Collections.Generic;
using System.Text;

namespace Sugar
{
    /// <summary>
    /// To CSV extension
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns a comma seprated value representation of this list of T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="seperator">The seperator.</param>
        /// <returns></returns>
        public static string ToCsv<T>(this IEnumerable<T> values, string seperator = ",")
        {
            var result = new StringBuilder();

            if (values != null)
            {
                foreach (var value in values)
                {
                    if (result.Length > 0) result.Append(seperator);

                    result.Append(value);
                }
            }

            return result.ToString();
        }
    }
}
