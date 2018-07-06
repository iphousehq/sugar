namespace Sugar.Core
{
    /// <summary>
    /// Interface to access an underlying resource (inspired by <see cref="Lazy{T}"/> but with an interface for easy mocking.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAccessor<T>
    {
        /// <summary>
        /// Accesses the underlying resource.
        /// </summary>
        /// <returns></returns>
        T Access();
    }
}
