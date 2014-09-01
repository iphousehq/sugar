using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sugar
{
    /// <summary>
    /// Assembly extentsion methods
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Gets the types from this assembly, optionally limiting those returned to Types
        /// within the specified namespace.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="namespace">The @namespace.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes(this Assembly assembly, string @namespace)
        {
            return assembly.GetTypes(new[] {@namespace});
        }

        /// <summary>
        /// Gets the types in the <see cref="assembly"/> that have a namespace starting with witht the given <see cref="namespaces"/>.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="namespaces">The namespaces.</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypes(this Assembly assembly, string[] @namespaces = null)
        {
            IEnumerable<Type> types;

            if (namespaces != null && namespaces.Length > 0)
            {
                var list = new List<Type>();

                foreach (var type in assembly.GetTypes())
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

                types = list;
            }
            else
            {
                types = assembly.GetTypes();
            }

            return types;
        }
    }
}
