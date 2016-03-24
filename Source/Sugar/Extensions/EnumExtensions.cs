using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Sugar.Extensions
{
    /// <summary>
    /// Enumeration methods for <see cref="Enum"/>
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets the attribute of type <see cref="T"/> from this <see cref="Enum"/> value. 
        /// </summary>
        /// <typeparam name="T">The type of attribute to obtain.</typeparam>
        /// <param name="value">The enumeration value.</param>
        /// <returns></returns>
        public static T GetAttributeFromEnumConstant<T>(this Enum value) where T : Attribute
        {
            return GetAttributesFromEnumConstant<T>(value).FirstOrDefault();
        }

        /// <summary>
        /// Gets the attributes of type <see cref="T"/> from this <see cref="Enum"/> value. 
        /// </summary>
        /// <typeparam name="T">The type of attribute to obtain.</typeparam>
        /// <param name="value">The enumeration value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributesFromEnumConstant<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();

            var memberInfo = type.GetMember(value.ToString());

            if (memberInfo.Length > 0)
            {
                foreach (var info in memberInfo)
                {
                    if (info.MemberType == MemberTypes.Field)
                    {
                        var attrs = info.GetCustomAttributes(typeof(T), true);

                        foreach (var attr in attrs)
                        {
                            yield return (T)attr;
                        }

                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the description of this <see cref="Enum"/> value.
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value)
        {
            return value.GetAttributePropertyFromEnumConstant<DescriptionAttribute, string>(p => p.Description, value.ToString());
        }

        /// <summary>
        /// Gets a property from the attribute of type <see cref="TProperty"/> from this <see cref="Enum"/> value. 
        /// </summary>
        /// <typeparam name="TAttribute">The type of the attribute.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="value">The enumeration value.</param>
        /// <param name="getPropertyFunc">The get property function.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static TProperty GetAttributePropertyFromEnumConstant<TAttribute, TProperty>(this Enum value, Func<TAttribute, TProperty> getPropertyFunc, TProperty defaultValue)
            where TAttribute : Attribute
        {
            var attribute = value.GetAttributeFromEnumConstant<TAttribute>();

            return attribute == null ? defaultValue : getPropertyFunc(attribute);
        }

        /// <summary>
        /// Gets the selected flags from this <see cref="Enum"/> 
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        /// <returns></returns>
        public static IEnumerable<Enum> GetFlags(this Enum value)
        {
            return Enum.GetValues(value.GetType())
                       .Cast<Enum>()
                       .Where(value.HasFlag);
        }
    }
}
