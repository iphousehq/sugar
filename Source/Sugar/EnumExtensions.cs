using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public static IEnumerable<TResult> GetFlagsValues<TEnum, TResult>(this Enum input)
        {
            // Can't add generic type rescription on enum :(
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("TEnum must be an enumeration");

            return Enum.GetValues(typeof (TEnum))
                .Cast<TResult>()
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
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="aggregateFunc">The aggregate func.</param>
        /// <returns></returns>
        public static Enum CombineAllToFlagsEnum<TResult>(this Enum input, Func<TResult, TResult, TResult> aggregateFunc)
        {
            return Combine(input.GetType(), (IEnumerable<TResult>)null, aggregateFunc);
        }

        /// <summary>
        /// Combines an enumerable of integers to a single flags enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="aggregateFunc">The aggregate func.</param>
        /// <returns></returns>
        public static Enum CombineToFlagsEnum<TEnum, TResult>(this IEnumerable<TResult> input, Func<TResult, TResult, TResult> aggregateFunc)
        {
            return Combine(typeof(TEnum), input, aggregateFunc);
        }

        /// <summary>
        /// Combines the specified enum type.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="enumType">Type of the enum.</param>
        /// <param name="input">The input.</param>
        /// <param name="aggregateFunc">The aggregate func.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        private static Enum Combine<TResult>(Type enumType, IEnumerable<TResult> input, Func<TResult, TResult, TResult> aggregateFunc)
        {
            // Can't add generic type description on enum :(
            if (!enumType.IsEnum) throw new ArgumentException("Enum type must be an enumeration");

            var result = Enum
                .GetValues(enumType)
                .Cast<TResult>()
                .Where(value => input == null || input.Contains(value))
                .Aggregate(default(TResult), aggregateFunc);

            return (Enum)Enum.ToObject(enumType, result);
        }

        /// <summary>
        /// Combines an enumerable of integers to a single flags enum value.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="aggregateFunc">The aggregate func.</param>
        /// <returns></returns>
        public static Enum CombineToFlagsEnum<TEnum, TResult>(this IEnumerable<string> input, Func<TResult, TResult, TResult> aggregateFunc)
        {
            return Combine(typeof(TEnum), input, aggregateFunc);
        }

        private static Enum Combine<TResult>(Type enumType, IEnumerable<string> input, Func<TResult, TResult, TResult> aggregateFunc)
        {
            // Can't add generic type description on enum :(
            if (!enumType.IsEnum) throw new ArgumentException("Enum type must be an enumeration");

            var result = Enum
                .GetValues(enumType)
                .Cast<object>()
                .Select(value => new
                {
                    value = (TResult) value, 
                    stringValue = value.ToString()
                })
                .Where(@t => input == null || input.Contains(@t.stringValue))
                .Select(@t => @t.value)
                .Aggregate(default(TResult), aggregateFunc);

            return (Enum)Enum.ToObject(enumType, result);
        }

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <param name="enumerationValue">The enumeration value.</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumerationValue)
        {
            return enumerationValue.GetAttributePropertyFromEnumConstant<DescriptionAttribute, string>(p => p.Description, enumerationValue.ToString());
        }

        /// <summary>
        /// Gets the property of an attribute attribute from an enum constant.
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="enumerationValue">The enumeration value.</param>
        /// <param name="getPropertyFunc">The get property function.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static TProperty GetAttributePropertyFromEnumConstant<TAttribute, TProperty>(this Enum enumerationValue, Func<TAttribute, TProperty> getPropertyFunc, TProperty defaultValue) 
            where TAttribute : Attribute
        {
            var attribute = enumerationValue.GetAttributeFromEnumConstant<TAttribute>();

            return attribute == null ? defaultValue : getPropertyFunc(attribute);
        }

        /// <summary>
        /// Gets the attribute from enum constant.
        /// </summary>
        /// <typeparam name="T">The type of attribute to obtain.</typeparam>
        /// <param name="enumerationValue">The enumeration value.</param>
        /// <returns></returns>
        public static T GetAttributeFromEnumConstant<T>(this Enum enumerationValue) where T : Attribute
        {
            return GetAttributesFromEnumConstant<T>(enumerationValue).FirstOrDefault();
        }

        /// <summary>
        /// Gets the attribute from enum constant.
        /// </summary>
        /// <typeparam name="T">The type of attribute to obtain.</typeparam>
        /// <param name="enumerationValue">The enumeration value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributesFromEnumConstant<T>(this Enum enumerationValue) where T : Attribute
        {
            var type = enumerationValue.GetType();

            var memberInfo = type.GetMember(enumerationValue.ToString());

            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(T), true);

                foreach (var attr in attrs)
                {
                    yield return (T) attr;
                }
            }
        }

        /// <summary>
        /// Parses the CSV list to a list of Enum values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="csv">The CSV.</param>
        /// <returns></returns>
        public static IList<T> ParseCsvToEnums<T>(this string csv) where T : struct
        {
            var results = new List<T>();

            var allValues = GetAllEnumValuesRemovalStatuses<T>();

            // Check input
            if (string.IsNullOrWhiteSpace(csv))
            {
                results = allValues;
            }
            else
            {
                var candidates = csv.Split(',');

                foreach (var candidate in candidates)
                {
                    T status;

                    if (Enum.TryParse(candidate, true, out status))
                    {
                        // Check status is valid
                        if (!allValues.Contains(status)) continue;

                        // Check for duplicates
                        if (results.Contains(status)) continue;

                        results.Add(status);
                    }
                }

                // Return everything if nothing selected
                if (results.Count == 0)
                {
                    results.AddRange(allValues);
                }
            }            
            return results;
        }
     
        /// <summary>
        /// Gets all the removal statuses
        /// </summary>
        /// <returns></returns>
        private static List<T> GetAllEnumValuesRemovalStatuses<T>()
        {
            var values = Enum.GetValues(typeof(T));

            return values.Cast<T>().ToList();
        }
    }
}
