using System;
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

        /// <summary>
        /// Gets the maximum index of the item in a list that matches the given filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static int GetMaximumIndexUsingFilter<T>(this IList<T> collection, Func<T, bool> filter)
        {
            var index = -1;

            for (var i = 0; i < collection.Count; i++)
            {
                if (filter.Invoke(collection[i]))
                {
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Gets the index of the first item in the list that matches the given filter.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static int GetIndexUsingFilter<T>(this IList<T> collection, Func<T, bool> filter)
        {
            for (var i = 0; i < collection.Count; i++)
            {
                if (filter.Invoke(collection[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Swaps the items at the specified indices.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The columns.</param>
        /// <param name="removeIndex">Index of the remove.</param>
        /// <param name="insertIndex">Index of the insert.</param>
        /// <returns></returns>
        public static IList<T> RemoveAndInsertAt<T>(this IList<T> collection, int removeIndex, int insertIndex)
        {
            var temp = collection[removeIndex];

            collection.RemoveAt(removeIndex);
            collection.Insert(insertIndex, temp);

            return collection;
        }

        /// <summary>
        /// Removes an item from the collection if a predicate evaluates to true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="predicate">The predicate.</param>
        public static void RemoveIf<T>(this IList<T> collection, Func<T, bool> predicate)
        {
            for (var counter = collection.Count - 1; counter >= 0; counter--)
            {
                var thisItem = collection[counter];

                if (predicate(thisItem))
                {
                    collection.RemoveAt(counter);
                }
            }
        }
    }
}
