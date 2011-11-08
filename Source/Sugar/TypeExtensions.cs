﻿using System;

namespace Sugar
{
    /// <summary>
    /// Extenions methods for <see cref="Type"/> objects.
    /// </summary>
    public static class TypeExtensions
    {
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