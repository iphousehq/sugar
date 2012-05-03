using System;
using System.Collections.Generic;

namespace Sugar.Mime
{
    /// <summary>
    /// Base MIME type.
    /// </summary>
    public abstract class BaseMime
    {
        protected BaseMime()
        {
            Extensions = new List<string>();
        }

        /// <summary>
        /// Gets or sets the extensions.
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public IList<string> Extensions { get; set; }

        /// <summary>
        /// Gets or sets the type of the base MIME.
        /// </summary>
        /// <value>
        /// The type of the base MIME.
        /// </value>
        public abstract BaseMimeType BaseMimeType { get; }

        /// <summary>
        /// Gets or sets the type of the MIME.
        /// </summary>
        /// <value>
        /// The type of the MIME.
        /// </value>
        public abstract Enum MimeType { get; }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("{0}/{1}", BaseMimeType.GetDescription(), MimeType.GetDescription());
        }
    }
}