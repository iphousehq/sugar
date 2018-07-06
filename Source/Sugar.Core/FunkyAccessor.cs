using System;

namespace Sugar.Core
{
    /// <summary>
    /// Implementation of <see cref="IAccessor{T}"/> that relies on a <see cref="Func{T}"/> to return the value.
    /// </summary>
    /// <remarks>The funk is invoked every time <see cref="Access"/> is called.</remarks>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Sugar.Core.IAccessor{T}" />
    public class FunkyAccessor<T> : IAccessor<T>
    {
        private Func<T> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FunkyAccessor{T}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public FunkyAccessor(Func<T> factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Invokes the factory.
        /// </summary>
        /// <returns></returns>
        public T Access()
        {
            return factory.Invoke();
        }
    }
}