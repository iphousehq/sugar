using System.ComponentModel;

namespace Sugar.Mime
{
    /// <summary>
    /// Mime sub-type for messages.
    /// </summary>
    public enum MessageMimeType
    {
        
        /// <summary>
        /// MHTML Document (Microsoft), Archived Webpage.
        /// </summary>
        [Description("rfc822")]
        Mht,
    }
}
