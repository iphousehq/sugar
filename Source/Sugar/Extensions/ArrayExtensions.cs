namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for arrays
    /// </summary>
    public static class ArrayExtensions
    {
        /// <summary>
        /// Slices this array to create a new array.
        /// </summary>
        /// <typeparam name="T"> The type of array. </typeparam>
        /// <param name="source">The array to slice.</param>
        /// <param name="start">The start index.</param>
        /// <param name="length">The length of the slice.</param>
        /// <returns></returns>
        public static T[] Slice<T>(this T[] source, int start, int length)
        {
            var result = new T[length];

            for (var i = 0; i < length; i++)
            {
                result[i] = source[i + start];
            }

            return result;
        }
    }
}
