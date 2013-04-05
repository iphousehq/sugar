using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Sugar.Xml;

namespace Sugar.Net
{
    /// <summary>
    /// Represents a file downloaded from the internet.
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponse"/> class.
        /// </summary>
        public HttpResponse()
        {
            Cookies = new CookieContainer();
            Headers = new Dictionary<string, string>();
        }

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
        /// Gets the cookies.
        /// </summary>
        /// <value>
        /// The cookies.
        /// </value>
        public CookieContainer Cookies { get; set; }

        /// <summary>
        /// Gets or sets the user agent used to make this response.
        /// </summary>
        /// <value>
        /// The user agent.
        /// </value>
        public UserAgent UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the HTTP response headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public IDictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets a value indicating whether the download operation completed successfully.
        /// </summary>
        /// <value><c>true</c> if [exception occured]; otherwise, <c>false</c>.</value>
        public bool Success
        {
            get { return Exception == null; }
        }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Gets or sets the status description.
        /// </summary>
        /// <value>
        /// The status description.
        /// </value>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the length of the content.
        /// </summary>
        /// <value>
        /// The length of the content.
        /// </value>
        public long ContentLength { get; set; }

        /// <summary>
        /// Converts the bytes in the response to a string assuming it is UTF-8 encoded.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents the <see cref="Bytes"/>.
        /// </returns>
        public override string ToString()
        {
            return ToString(Encoding.UTF8);
        }

        /// <summary>
        /// Converts the bytes in the response given the specified encoding
        /// </summary>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public String ToString(Encoding encoding)
        {
            var result = string.Empty;

            if (Bytes != null && Bytes.Length > 0)
            {
                result = encoding.GetString(Bytes);
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
        /// Returns an XML representation of the response.
        /// </summary>
        /// <returns></returns>
        public XPathDocument ToXPath()
        {
            return ToString().ToXPath();
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
