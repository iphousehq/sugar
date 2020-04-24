using System;
using System.Linq;
using System.Reflection;

namespace Sugar.Command.Binder
{
    /// <summary>
    /// Class to bind command line parameters to objects
    /// </summary>
    public static class ParameterBinder
    {
        /// <summary>
        /// Binds the specified parameters.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns>
        /// An instance of <see cref="T"/> with values mapped to its properties.
        /// Otherwise null is returned when a required parameter is missing.
        /// </returns>
        public static T Bind<T>(Parameters parameters) where T : new()
        {
            var result = new T();

            // Bind properties
            var properties = typeof (T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(bool))
                {
                    var flag = (FlagAttribute) property.GetCustomAttributes(typeof(FlagAttribute), false).FirstOrDefault();

                    if (flag != null)
                    {
                        property.SetValue(result, parameters.ContainsAny(flag.Names), null);
                    }
                }

                var attribute = (ParameterAttribute) property.GetCustomAttributes(typeof (ParameterAttribute), false).FirstOrDefault();

                if (attribute == null) continue;

                var set = false;

                // Property by name
                if (attribute.HasName && parameters.HasValue(attribute.GetName()))
                {
                    property.SetValue(result, parameters.AsCustomType(attribute.GetName(), property.PropertyType), null);

                    set = true;
                }

                // Property by position
                if (attribute.HasPosition && attribute.GetPosition() < parameters.Count)
                {
                    property.SetValue(result, parameters.AsCustomType(attribute.GetPosition(), property.PropertyType), null);

                    set = true;
                }

                // Set default value
                if (!set && !attribute.Required && !string.IsNullOrWhiteSpace(attribute.Default))
                {
                    property.SetValue(result, Convert.ChangeType(attribute.Default, property.PropertyType), null);

                    set = true;
                }

                // Attribute required check
                if (set || !attribute.Required) continue;

                throw new RequiredParameterMissingException($"Required parameter \"{attribute.GetName()}\" missing or without corresponding value", property.Name);
            }

            return result;
        }
    }
}
