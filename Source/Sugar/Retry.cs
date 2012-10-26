using System;
using System.Threading;

namespace Sugar
{
    public static class Retry
    {
        public static T This<T>(Func<T> action, int numRetries, int retryTimeout)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
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
            }
            while (numRetries-- > 0);

            return default(T);
        }
    }
}
