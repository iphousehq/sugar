using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="Assembly"/>
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets the types in this <see cref="assembly"/> that have a namespace starting with with the given <see cref="namespaces"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes(this Assembly assembly, params string[] @namespaces)
        {
            IEnumerable<Type> types;

            if (namespaces != null && namespaces.Length > 0 && !string.IsNullOrEmpty(namespaces[0]))
            {
                var list = new List<Type>();

                foreach (var type in assembly.GetTypes())
                {
                    if (type.HasAttribute<CompilerGeneratedAttribute>() == false)
                    {
                        if (!string.IsNullOrEmpty(type.Namespace))
                        {
                            foreach (var namespaceStart in namespaces)
                            {
                                if (type.Namespace.StartsWith(namespaceStart))
                                {
                                    list.Add(type);
                                }
                            }
                        }
                    }
                }

                types = list;
            }
            else
            {
                types = assembly.GetTypes();
            }

            return types;
        }

        /// <summary>
        /// Gets all the types in this assembly decorated with the given attribute.
        /// </summary>
        /// <typeparam name="T">The type of the attribute.</typeparam>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWith<T>(this Assembly assembly)
        {
            return assembly.GetTypes()
                           .Where(type => type.GetCustomAttributes(typeof (T), true).Length > 0);
        }
    }
}
