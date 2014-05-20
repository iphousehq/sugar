using System.Collections.Generic;

namespace Sugar
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds an item to the specified list if it is not already contained in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="item">The item.</param>
        public static void AddIfNotExists<T>(this ICollection<T> collection, T item)
        {
            if (!collection.Contains(item))
            {
                collection.Add(item);
            }
        }
    }
}
