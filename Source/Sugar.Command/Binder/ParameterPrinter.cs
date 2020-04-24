using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sugar.Command.Binder
{
    /// <summary>
    /// Class to output command line parameters.
    /// </summary>
    public class ParameterPrinter
    {
        /// <summary>
        /// Prints the parameters required to bind to the given types in an assembly with
        /// the specified name.
        /// </summary>
        /// <param name="switch">The @switch.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="className">Name of the class.</param>
        /// <returns></returns>
        public IList<string> Print(string @switch, Assembly assembly, string className = "Options")
        {
            var types = assembly.GetTypes()
                                .Where(t => t.Name == className)
                                .ToArray();

            return Print(@switch, types);
        }

        /// <summary>
        /// Prints the parameters required to bind to the given types
        /// </summary>
        /// <param name="switch">The @switch.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public IList<string> Print(string @switch, params Type[] types)
        {
            var results = new List<string>();

            foreach (var type in types)
            {
                var result = string.Empty;

                var attributes = type.GetCustomAttributes(typeof(FlagAttribute), false);

                // Check class flags
                foreach (FlagAttribute attribute in attributes)
                {
                    foreach (var name in attribute.Names)
                    {
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            result += " ";
                        }

                        result += @switch;
                        result += name;                        
                    }
                }

                // Bind properties
                var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

                foreach (var property in properties)
                {                   
                    var attribute = (ParameterAttribute)property.GetCustomAttributes(typeof(ParameterAttribute), false).FirstOrDefault();

                    if (attribute != null && attribute.HasName)
                    {
                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            result += " ";
                        }

                        if (!attribute.Required)
                        {
                            result += "[";
                        }

                        // Property by name
                        result += @switch;
                        result += attribute.GetName();

                        // Set default value
                        result += AppendParameterHint(property, attribute);

                        if (!attribute.Required)
                        {
                            result += "]";
                        }
                    }

                    var flagAttributes = property.GetCustomAttributes(typeof(FlagAttribute), false);

                    // Check class flags
                    foreach (FlagAttribute flagAttribute in flagAttributes)
                    {
                        foreach (var name in flagAttribute.Names)
                        {
                            if (!string.IsNullOrWhiteSpace(result))
                            {
                                result += " ";
                            }

                            result += "[";
                            result += @switch;
                            result += name;
                            result += "]";
                        }
                    }
                }

                results.Add(result);
            }
          
            return results;
        }

        /// <summary>
        /// Appends the parameter hint.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="attribute">The attribute.</param>
        /// <returns></returns>
        private string AppendParameterHint(PropertyInfo property, ParameterAttribute attribute)
        {
            var result = " ";

            if (!string.IsNullOrWhiteSpace(attribute.Default))
            {
                switch (property.PropertyType.Name)
                {
                    case "String":
                        result += @"""" + attribute.Default +  @"""";
                        break;

                    default:
                        result += attribute.Default;
                        break;
                }
            }
            else
            {
                switch (property.PropertyType.Name)
                {
                    case "String":
                        result += @"""abc""";
                        break;

                    case "Int16":
                    case "Int32":
                    case "Int64":
                        result += @"123";
                        break;

                    case "Double":
                    case "Float":
                        result += @"123.4";
                        break;

                    default:
                        result += @"(" + property.PropertyType.Name + ")";
                        break;
                }
            }

            return result;
        }
    }
}
