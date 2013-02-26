using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;

namespace Sugar.Json
{
    /// <summary>
    /// Helper methods for using JSON.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Decodes a JSON string and returns a dynamic object.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        /// <remarks>
        /// Dynamic decoder adopted from Shawn Weisfeld, http://bit.ly/jPqVsQ
        /// via
        /// https://github.com/robconery/Manatee
        /// </remarks>
        public static dynamic DecodeJson(this string json)
        {
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new DynamicJsonConverter() });

            dynamic obj = serializer.Deserialize(json, typeof(object));

            return obj;
        }

        /// <summary>
        /// Encodes a JSON object as a string.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static string EncodeJson(this object json)
        {
            var serializer = new JavaScriptSerializer();

            return serializer.Serialize(json);
        }

        #region Json Convert

        /// <summary>
        /// Converts the JSON to string.
        /// </summary>
        /// <param name="json">The JSON.</param>
        /// <returns></returns>
        public static string ConvertJsonToString(dynamic json)
        {
            return json == null ? string.Empty : json.ToString();
        }

        /// <summary>
        /// Converts the JSON to int.
        /// </summary>
        /// <param name="json">The JSON.</param>
        /// <returns></returns>
        public static int ConvertJsonToInt(dynamic json)
        {
            string s = ConvertJsonToString(json);

            return string.IsNullOrEmpty(s) ? default(int) : Int32.Parse(s);
        }

        /// <summary>
        /// Converts the JSON to double.
        /// </summary>
        /// <param name="json">The JSON.</param>
        /// <returns></returns>
        public static double ConvertJsonToDouble(dynamic json)
        {
            string s = ConvertJsonToString(json);

            return string.IsNullOrEmpty(s) ? default(double) : Double.Parse(s);
        }

        /// <summary>
        /// Converts the JSON to bool.
        /// </summary>
        /// <param name="json">The JSON.</param>
        /// <returns></returns>
        public static bool ConvertJsonToBool(dynamic json)
        {
            string s = ConvertJsonToString(json);

            return string.IsNullOrEmpty(s) ? default(bool) : Boolean.Parse(s);
        }

        /// <summary>
        /// Converts the JSON to item source.
        /// </summary>
        /// <param name="json">The JSON.</param>
        /// <returns></returns>
        public static TEnum ConvertJsonToEnum<TEnum>(dynamic json) where TEnum : struct
        {
            string s = ConvertJsonToString(json);

            var result = default(TEnum);

            if (!string.IsNullOrEmpty(s))
            {
                if (Enum.TryParse(s, out result))
                {
                    return result;
                }

                throw new ApplicationException(string.Format("Could not convert JSON value {0} to enum of type {1}", s, typeof(TEnum).Name));
            }

            return result;
        }

        #endregion

        #region Dynamic JSON Converter

        /// <summary>
        /// Dynamic converter for JSON
        /// </summary>
        private sealed class DynamicJsonConverter : JavaScriptConverter
        {
            /// <summary>
            /// When overridden in a derived class, converts the provided dictionary into an object of the specified type.
            /// </summary>
            /// <param name="dictionary">An <see cref="T:System.Collections.Generic.IDictionary`2" /> instance of property data stored as name/value pairs.</param>
            /// <param name="type">The type of the resulting object.</param>
            /// <param name="serializer">The <see cref="T:System.Web.Script.Serialization.JavaScriptSerializer" /> instance.</param>
            /// <returns>
            /// The deserialized object.
            /// </returns>
            /// <exception cref="System.ArgumentNullException"></exception>
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");

                return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
            }

            /// <summary>
            /// When overridden in a derived class, builds a dictionary of name/value pairs.
            /// </summary>
            /// <param name="obj">The object to serialize.</param>
            /// <param name="serializer">The object that is responsible for the serialization.</param>
            /// <returns>
            /// An object that contains key/value pairs that represent the object’s data.
            /// </returns>
            /// <exception cref="System.NotImplementedException"></exception>
            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// When overridden in a derived class, gets a collection of the supported types.
            /// </summary>
            /// <returns>An object that implements <see cref="T:System.Collections.Generic.IEnumerable`1" /> that represents the types supported by the converter.</returns>
            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
            }
        }

        #endregion
    }
}
      