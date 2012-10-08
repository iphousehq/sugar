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

    /// <summary>
    /// A dynamic json object
    /// </summary>
    public class DynamicJsonObject : DynamicObject
    {
        private readonly IDictionary<string, object> _dictionary;

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicJsonObject" /> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        public DynamicJsonObject(IDictionary<string, object> dictionary)
        {
            if (dictionary == null)
                throw new ArgumentNullException("dictionary");
            _dictionary = dictionary;
        }

        /// <summary>
        /// Provides the implementation for operations that get member values. Classes derived from the <see cref="T:System.Dynamic.DynamicObject" /> class can override this method to specify dynamic behavior for operations such as getting a value for a property.
        /// </summary>
        /// <param name="binder">Provides information about the object that called the dynamic operation. The binder.Name property provides the name of the member on which the dynamic operation is performed. For example, for the Console.WriteLine(sampleObject.SampleProperty) statement, where sampleObject is an instance of the class derived from the <see cref="T:System.Dynamic.DynamicObject" /> class, binder.Name returns "SampleProperty". The binder.IgnoreCase property specifies whether the member name is case-sensitive.</param>
        /// <param name="result">The result of the get operation. For example, if the method is called for a property, you can assign the property value to <paramref name="result" />.</param>
        /// <returns>
        /// true if the operation is successful; otherwise, false. If this method returns false, the run-time binder of the language determines the behavior. (In most cases, a run-time exception is thrown.)
        /// </returns>
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

        /// <summary>
        /// Determines whether the specified name has member.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if the specified name has member; otherwise, <c>false</c>.
        /// </returns>
        public bool HasMember(string name)
        {
            return _dictionary.Keys.Contains(name);
        }
    }
}
      