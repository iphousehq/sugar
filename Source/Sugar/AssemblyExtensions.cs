using System;
using System.Collections.Generic;
using System.Linq;
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
        public static IEnumerable<Type> GetTypes(this Assembly assembly, string @namespace = "")
        {
            IEnumerable<Type> types;

            if (string.IsNullOrEmpty(@namespace))
            {
                types = assembly.GetTypes();
            }
            else
            {
                types = assembly
                    .GetTypes()
                    .Where(t => !string.IsNullOrEmpty(t.Namespace) &&
                                t.Namespace.StartsWith(@namespace));
            }

            return types;
        }
    }
}
