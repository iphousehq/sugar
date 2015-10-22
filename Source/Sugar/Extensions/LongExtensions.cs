using System;

namespace Sugar.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="long"/> 
    /// </summary>
    public static class LongExtensions
    {
        /// <summary>
        /// Converts a unix epoch time to a DateTime instance.
        /// </summary>
        /// <param name="unixTime">The unix time.</param>
        /// <returns></returns>
        public static DateTime FromUnixTime(this long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            return epoch.AddSeconds(unixTime);
        }
    }
}