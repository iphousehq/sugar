using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extenions methods for <see cref="Type"/> objects.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Gets the given attribute <see cref="T"/> from the given type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type)
        {
            var attributes = type.GetCustomAttributes(typeof(T), false);

            if (attributes.Length > 0)
            {
                return (T) attributes[0];
            }

            return default(T);
        }

        /// <summary>
        /// Gets the public properties from this type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static IList<PropertyInfo> GetPublicProperties(this Type type)
        {
            return type.GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList();
        }

        /// <summary>
        /// Determines whether this type has the given attribute <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type has attribute; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasAttribute<T>(this Type type)
        {
            var attributes = type.GetCustomAttributes(typeof (T), false);

            return attributes.Length > 0;
        }

        /// <summary>
        /// Determines whether this type implements the specified interface.
        /// </summary>
        /// <param name="type">Type of the object.</param>
        /// <param name="interface">The @interface.</param>
        /// <returns>
        ///   <c>true</c> if the specified object type is implementing; otherwise, <c>false</c>.
        /// </returns>
        public static bool ImplementsInterface(this Type type, Type @interface)
        {
            return type.GetInterfaces().Any(i => i == @interface);
        }

        /// <summary>
        /// Gets the Namespace and Name of this type, including any generic parameters.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public static string ToGenericFullName(this Type type)
        {
            var result = string.Empty;

            if (type != null)
            {
                result = type.FullName;

                if (type.IsGenericTypeDefinition || type.IsGenericType)
                {
                    result = type.GetGenericTypeDefinition().FullName.SubstringBeforeChar("`") + "<";

                    var args = type.GetGenericArguments();

                    var sb = string.Empty;

                    foreach (var arg in args)
                    {
                        if (!string.IsNullOrEmpty(sb)) sb += ", ";
                        result += arg.Name;
                    }

                    result += sb + ">";
                }
            }

            return result;
        }
    }
}
