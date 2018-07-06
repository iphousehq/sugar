using System;

namespace Sugar.Core
{
    /// <summary>
    /// Convenience class to warp calls to <see cref="DateTime.Now"/> and <see cref="DateTime.UtcNow"/>.
    /// </summary>
    /// <seealso cref="INow" />
    public class Now : INow
    {
        /// <summary>
        /// Gets the current date and time on this computer expressed in local time.
        /// </summary>
        /// <value>
        /// The local date time.
        /// </value>
        public DateTime Local => DateTime.Now;

        /// <summary>
        /// Gets the current date and time on this computer expressed in UTC.
        /// </summary>
        /// <value>
        /// The UTC date time.
        /// </value>
        public DateTime Utc => DateTime.UtcNow;
    }
}