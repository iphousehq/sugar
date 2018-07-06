namespace Sugar.Core
{
    /// <summary>
    /// Implementation of <see cref="IAccessor{T}"/> that relies on a private variable to return the value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Sugar.Core.IAccessor{T}" />
    public class WrapperAccessor<T> : IAccessor<T>
    {
        private T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="WrapperAccessor{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public WrapperAccessor(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns the private variable set in the <see cref="WrapperAccessor{T}"/> constructor.
        /// </summary>
        /// <returns></returns>
        public T Access()
        {
            return value;
        }
    }
}