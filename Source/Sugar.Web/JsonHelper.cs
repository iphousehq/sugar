using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Web.Script.Serialization;

namespace Sugar
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

        private sealed class DynamicJsonConverter : JavaScriptConverter
        {
            public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
            {
                if (dictionary == null)
                    throw new ArgumentNullException("dictionary");

                return type == typeof(object) ? new DynamicJsonObject(dictionary) : null;
            }

            public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
            {
                throw new NotImplementedException();
            }

            public override IEnumerable<Type> SupportedTypes
            {
                get { return new ReadOnlyCollection<Type>(new List<Type>(new[] { typeof(object) })); }
            }
        }

    }

    public class DynamicJsonObject : DynamicObject
    {
        private readonly IDictionary<string, object> _dictionary;



        public DynamicJsonObject(IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            _dictionary = dictionary;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (!_dictionary.TryGetValue(binder.Name, out result))
            {
                // return null to avoid exception.  caller can check for null this way...
                result = null;
                return true;
            }

            var dictionary = result as IDictionary<string, object>;
            if (dictionary != null)
            {
                result = new DynamicJsonObject(dictionary);
                return true;
            }

            var arrayList = result as ArrayList;
            if (arrayList != null && arrayList.Count > 0)
            {
                if (arrayList[0] is IDictionary<string, object>)
                    result =
                        new List<object>(
                            arrayList.Cast<IDictionary<string, object>>().Select(x => new DynamicJsonObject(x)));
                else
                    result = new List<object>(arrayList.Cast<object>());
            }

            return true;

        }

        public bool HasMember(string name)
            {
                return _dictionary.Keys.Contains(name);
            }

        }

}
      