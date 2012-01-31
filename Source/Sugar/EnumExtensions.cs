using System;
using System.Collections.Generic;
using System.Linq;

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

            var value = source.ToString();

            try
            {
                return (TResult)Enum.Parse(typeof(TResult), value);
            }
            catch
            {
                throw new InvalidCastException(string.Format("Error converting {0} (value '{1}') to {2}", source.GetType(), source, typeof(TResult)));
            }
        }

        /// <summary>
        /// Gets the flags that are selected.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<Enum> GetFlags(this Enum input)
        {
            return Enum.GetValues(input.GetType())
                .Cast<Enum>()
                .Where(input.HasFlag);
        }

        /// <summary>
        /// Gets the values of the flags that are selected.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<int> GetFlagsValues<TEnum>(this Enum input)
        {
            // Can't add generic type rescription on enum :(
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum must be an enumeration");

            return Enum.GetValues(typeof (TEnum))
                .Cast<int>()
                .Select(value => new
                {
                    value, 
                    enumValue = (Enum) Enum.ToObject(typeof (TEnum), value)
                })
                .Where(@t => input.HasFlag(@t.enumValue))
                .Select(@t => @t.value);
        }


        /// <summary>
        /// Combines all enumerable values to a single flags enum.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Enum CombineAllToFlagsEnum(this Enum input)
        {
            return Combine(input.GetType(), (IEnumerable<int>) null);
        }

        /// <summary>
        /// Combines an enumerable of integers to a single flags enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Enum CombineToFlagsEnum<TEnum>(this IEnumerable<int> input)
        {
            return Combine(typeof(TEnum), input);
        }

        private static Enum Combine(Type enumType, IEnumerable<int> input)
        {
            // Can't add generic type description on enum :(
            if (!enumType.IsEnum) throw new ArgumentException("Enum type must be an enumeration");

            var result = Enum
                .GetValues(enumType)
                .Cast<int>()
                .Where(value => input == null || input.Contains(value))
                .Aggregate(0, (current, value) => current | value);

            return (Enum)Enum.ToObject(enumType, result);
        }

        /// <summary>
        /// Combines an enumerable of integers to a single flags enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static Enum CombineToFlagsEnum<TEnum>(this IEnumerable<string> input)
        {
            return Combine(typeof(TEnum), input);
        }

        private static Enum Combine(Type enumType, IEnumerable<string> input)
        {
            // Can't add generic type description on enum :(
            if (!enumType.IsEnum) throw new ArgumentException("Enum type must be an enumeration");

            var result = Enum
                .GetValues(enumType)
                .Cast<object>()
                .Select(value => new
                {
                    value, 
                    stringValue = value.ToString()
                })
                .Where(@t => input == null || input.Contains(@t.stringValue))
                .Select(@t => @t.value)
                .Aggregate(0, (current, value) => current | (int) value);

            return (Enum)Enum.ToObject(enumType, result);
        }
    }
}
