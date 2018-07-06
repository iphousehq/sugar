using System;

namespace Sugar.Core
{
    /// <summary>
    /// Interface to warp calls to <see cref="DateTime.Now"/> and <see cref="DateTime.UtcNow"/>.
    /// </summary>
    public interface INow
    {
        /// <summary>
        /// Gets the local.
        /// </summary>
        /// <value>
        /// The local.
        /// </value>
        DateTime Local { get; }

        /// <summary>
        /// Gets the current date and time on this computer expressed in UTC.
        /// </summary>
        /// <value>
        /// The UTC date time.
        /// </value>
        DateTime Utc { get; }
    }
}
