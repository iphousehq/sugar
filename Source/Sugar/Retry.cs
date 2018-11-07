using System;
using System.Threading;

namespace Sugar
{
    /// <summary>
    /// Helper class to retry a given action n times.
    /// </summary>
    public static class Retry
    {
        /// <summary>
        /// Retries a given action n times for a specified timeout (in miliseconds).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action">The action.</param>
        /// <param name="numRetries">The number of retries.</param>
        /// <param name="retryTimeout">The retry timeout (mili seconds).</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">action</exception>
        public static T This<T>(Func<T> action, int numRetries, int retryTimeout)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            do
            {
                try
                {
                    return action.Invoke();
                }
                catch
                {
                    // Avoid silent failures
                    if (numRetries <= 0) throw;

                    Thread.Sleep(retryTimeout);
                }
            } while (numRetries-- > 0);

            return default(T);
        }
    }
}
