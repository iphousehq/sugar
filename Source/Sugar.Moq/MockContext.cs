using System;
using System.Collections.Generic;
using Moq;

namespace Sugar.Moq
{
    /// <summary>
    /// Helps keeping track of multiple mocks.
    /// </summary>
    public class MockContext
    {
        private readonly IDictionary<Type, object> mocks = new Dictionary<Type, object>();

        /// <summary>
        /// Determines whether the context has a mocked object for the specified key.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>
        ///   <c>true</c> if the specified type contains key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey(Type type)
        {
            return mocks.ContainsKey(type);
        }

        /// <summary>
        /// Determines whether the context has a mocked object for the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>
        ///   <c>true</c> if this instance contains key; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsKey<T>()
        {
            return ContainsKey(typeof(T));
        }

        /// <summary>
        /// Instantiates a mock of <see cref="T"/> in the underlying mocks dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public MockContext AddMock<T>() where T : class
        {
            var type = typeof (T);

            var mock = new Mock<T>();

            return AddMock(type, mock);
        }
        
        /// <summary>
        /// Adds the specified <see cref="mock"/> for the given <see cref="key"/> in the underlying mocks dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public MockContext AddMock(Type key, Mock mock) 
        {
            mocks.Add(key, mock);

            return this;
        }

        /// <summary>
        /// Gets the mocked instance for the given <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The mock.</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public Mock<T> Get<T>() where T : class
        {
            var type = typeof (T);

            try
            {
                return (Mock<T>) mocks[type];
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"The key \"{type}\" was not present in the dictionary.", ex);
            }
        }

        /// <summary>
        /// Gets the underlying mocked object for the given <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>The mocked object.</returns>
        /// <exception cref="KeyNotFoundException"></exception>
        public T Of<T>() where T : class
        {
            return Get<T>().Object;
        }
    }
}