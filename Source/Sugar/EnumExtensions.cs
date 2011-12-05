using System;

namespace Sugar
{
    /// <summary>
    /// Enumeration extension methods
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an Enum to another enum matching on their string value.
        /// </summary>
        /// <typeparam name="TResult">The type of the result (must be an enum).</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static TResult ToEnum<TResult>(this Enum source)
        {
            // Can't add generic type rescription on enum :(
            if (!typeof(TResult).IsEnum) throw new ArgumentException("TResult must be an enumeration");

            string value = source.ToString();

            try
            {
                return (TResult)Enum.Parse(typeof(TResult), value);
            }
            catch
            {
                throw new InvalidCastException(string.Format("Error converting {0} (value '{1}') to {2}", source.GetType(), source, typeof(TResult)));
            }
        }

    }
}
