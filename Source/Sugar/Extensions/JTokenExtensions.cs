using Newtonsoft.Json.Linq;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="JToken"/> class.
    /// </summary>
    public static class JTokenExtensions
    {
        /// <summary>
        /// Gets the property cast to a type.
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="token">The JToken.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static T GetProperty<T>(this JToken token, string propertyName)
        {
            var value = token[propertyName];

            return value == null ? default : value.ToObject<T>();
        }

        /// <summary>
        /// Gets the property cast to a type and selected from a JSON path.
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="token">The JToken.</param>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public static T GetPropertyFromPaths<T>(this JToken token, params string[] paths)
        {
            var value = token;

            foreach (var path in paths)
            {
                value = value[path];

                if (value == null) break;
            }

            return value == null ? default : value.ToObject<T>();
        }

        /// <summary>
        /// Gets the property cast to a type and selected from a JSON path.
        /// </summary>
        /// <typeparam name="T">The type to cast to</typeparam>
        /// <param name="token">The JToken.</param>
        /// <param name="propertyPath">Path of the property.</param>
        /// <returns></returns>
        public static T GetPropertyFromPath<T>(this JToken token, string propertyPath)
        {
            var value = token.SelectToken(propertyPath);

            return value == null ? default : value.ToObject<T>();
        }

        /// <summary>
        /// Gets the property cast to an array.
        /// </summary>
        /// <param name="token">The JToken.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static JArray GetArray(this JToken token, string propertyName)
        {
            return token[propertyName] as JArray;
        }

        /// <summary>
        /// Gets the property cast to an array and selected from a JSON path.
        /// </summary>
        /// <param name="token">The JToken.</param>
        /// <param name="propertyPath">Path of the property.</param>
        /// <returns></returns>
        public static JArray GetArrayFromPath(this JToken token, string propertyPath)
        {
            var value = token.SelectToken(propertyPath);

            return value as JArray;
        }
    }
}