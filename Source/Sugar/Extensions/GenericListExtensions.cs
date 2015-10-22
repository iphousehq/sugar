using System;
using System.Collections.Generic;
using System.Linq;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="IList{T}"/> objects
    /// </summary>
    public static class GenericListExtensions
    {
        /// <summary>
        /// Adds an item to this list if it is not already contained in this list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="item">The item.</param>
        public static void AddIfNotExists<T>(this IList<T> list, T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// Split this list into chunks.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Chunkify<T>(this IList<T> list, int size)
        {
            for (var i = 0; i < list.Count; i += size)
            {
                yield return list.Skip(i)
                                 .Take(size)
                                 .ToList();
            }
        }

        /// <summary>
        /// Swaps the items in this list at the specified indices.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="removeIndex">Index of the remove.</param>
        /// <param name="insertIndex">Index of the insert.</param>
        /// <returns></returns>
        public static IList<T> RemoveAndInsertAt<T>(this IList<T> list, int removeIndex, int insertIndex)
        {
            var temp = list[removeIndex];

            list.RemoveAt(removeIndex);
            list.Insert(insertIndex, temp);

            return list;
        }

        /// <summary>
        /// Removes an item from this list if a predicate evaluates to true.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="predicate">The predicate.</param>
        public static void RemoveIf<T>(this IList<T> list, Func<T, bool> predicate)
        {
            for (var counter = list.Count - 1; counter >= 0; counter--)
            {
                var thisItem = list[counter];

                if (predicate(thisItem))
                {
                    list.RemoveAt(counter);
                }
            }
        }
    }
}