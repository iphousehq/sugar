using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar
{
    /// <summary>
    /// Extensions for generic IDictionary
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Gets the keys from a value.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="value">The value.</param>
        /// <param name="equalityComparer">The equality comparer.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static IEnumerable<TKey> GetKeysFromValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value, EqualityComparer<TValue> equalityComparer = null)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException("dictionary");
            }

            var comparer = equalityComparer ?? EqualityComparer<TValue>.Default;

            return dictionary.Keys.Where(key => comparer.Equals(dictionary[key], value));
        }
    }
}