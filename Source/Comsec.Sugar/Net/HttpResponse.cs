using System;
using System.Drawing;
using System.Text;
using System.Xml;
using Comsec.Sugar.Html;

namespace Comsec.Sugar.Net
{
    /// <summary>
    /// Represents a file downloaded from the internet.
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the stream.
        /// </summary>
        /// <value>The stream.</value>
        public byte[] Bytes { get; set; }

        /// <summary>
        /// Gets or sets the web exception.
        /// </summary>
        /// <value>The web exception.</value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets a value indicating whether the download operation completed successfully.
        /// </summary>
        /// <value><c>true</c> if [exception occured]; otherwise, <c>false</c>.</value>
        public bool Success
        {
            get { return Exception == null; }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var result = string.Empty;

            if (Bytes != null && Bytes.Length > 0)
            {
                result = Encoding.UTF8.GetString(Bytes);
            }

            return result;
        }

        /// <summary>
        /// Returns an XML representation of the response.
        /// </summary>
        /// <returns></returns>
        public XmlDocument ToXml()
        {
            var document = new XmlDocument();

            document.LoadXml(ToString());

            return document;
        }

        /// <summary>
        /// Returns the HTML representation of the response.
        /// </summary>
        /// <returns></returns>
        public HtmlDocument ToHtml()
        {
            return new HtmlDocument(ToString());
        }

        /// <summary>
        /// Returns the Bitmap represenation of the response.
        /// </summary>
        /// <returns></returns>
        public virtual Bitmap ToBitmap()
        {
            return Bytes.ToBitmap();
        }
    }
}
