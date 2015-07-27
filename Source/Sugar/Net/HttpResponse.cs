using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Sugar.Net
{
    /// <summary>
    /// Represents a file downloaded from the internet.
    /// </summary>
    [Serializable]
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
        /// Gets or sets the URL of the request.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the URL the original request might have been redirected to.
        /// </summary>
        /// <value>
        /// The redirected URL.
        /// </value>
        public string RedirectedUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the request followed a HTTP redirect (302) response.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [was redirected]; otherwise, <c>false</c>.
        /// </value>
        public bool WasRedirected
        {
            get { return Url != RedirectedUrl; }
        }

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
        /// Gets the encoding.
        /// </summary>
        /// <returns></returns>
        public Encoding GetEncoding()
        {
            var encoding = Encoding.UTF8;

            if (Headers.ContainsKey("Content-Type"))
            {
                var contentTypeHeader = Headers["Content-Type"];

                var charset = contentTypeHeader.SubstringAfterChar("charset=");

                try
                {
                    encoding = Encoding.GetEncoding(charset);
                }
                catch (ArgumentException)
                {
                    // If the charset found is not a valid encoding then default to UTF8
                }
            }

            return encoding;
        }

        /// <summary>
        /// Converts the bytes in the response to a string assuming it is UTF-8 encoded.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents the <see cref="Bytes"/>.
        /// </returns>
        public override string ToString()
        {
            var encoding = GetEncoding();

            return ToString(encoding);
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
    }
}
