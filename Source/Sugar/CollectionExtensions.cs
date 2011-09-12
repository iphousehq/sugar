using System.Collections.Generic;

namespace Sugar
{
    public static class CollectionExtensions
    {
        /// <summary>
        /// Adds an item to the specified list if it is not already contained in the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item">The item.</param>
        public static void AddIfNotExists<T>(this ICollection<T> list, T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }
    }
}
