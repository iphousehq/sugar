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
        /// Configures a mock for the given <see cref="T"/> and adds it to the underlying mocks dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public MockContext AddMock<T>() where T : class
        {
            var type = typeof (T);

            var mock = new Mock<T>();

            mocks.Add(type, mock);

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