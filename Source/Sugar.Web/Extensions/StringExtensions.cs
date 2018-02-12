using System;
using System.IO;
using System.Linq;
using Sugar.Mime;

namespace Sugar.Extensions
{
    /// <summary>
    /// String extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Gets the content type of a file from this string
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        /// <exception cref="System.ApplicationException">When the mime type cannot be determined.</exception>
        public static BaseMime GetMimeType(this string filename)
        {
            var mimeTypes = MimeTypes.Generate();

            var extension = Path.GetExtension(filename);

            if (string.IsNullOrEmpty(extension)) extension = "";

            extension = extension.Replace(".", "").ToLower();

            var result = mimeTypes.FirstOrDefault(m => m.Extensions.Contains(extension));

            if (result == null)
            {
                throw new ApplicationException($"Unkown extension to get mime type for filename '{filename}'");
            }

            return result;
        }
    }
}
