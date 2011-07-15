using System.Collections.Specialized;

namespace Comsec.Sugar.Net
{
    /// <summary>
    /// Represents a request to download a file from the internet
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRequest"/> class.
        /// </summary>
        public HttpRequest()
        {
            UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; pl; rv:1.9.1) Gecko/20090624 Firefox/3.5 (.NET CLR 3.5.30729)";

            Retries = 3;

            Headers = new NameValueCollection();

            Timeout = 10000;
        }

        /// <summary>
        /// Gets or sets the URL to download.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>The user agent.</value>
        public string UserAgent { get; set; }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        /// <value>
        /// The content tent.
        /// </value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the timeout.
        /// </summary>
        /// <value>
        /// The timeout.
        /// </value>
        public int Timeout { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to use basic authentication.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use basic authentication]; otherwise, <c>false</c>.
        /// </value>
        public bool UseBasicAuthentication { get; set; }

        /// <summary>
        /// Gets a value indicating whether to use authentication for this request
        /// </summary>
        /// <value><c>true</c> if [use authentication]; otherwise, <c>false</c>.</value>
        public bool UseAuthentication
        {
            get { return !(string.IsNullOrEmpty(Username) && string.IsNullOrEmpty(Password)); }
        }

        /// <summary>
        /// Gets or sets the number of retries if the download fails.
        /// </summary>
        /// <value>
        /// The retries.
        /// </value>
        public int Retries { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public NameValueCollection Headers { get; private set; }

        /// <summary>
        /// Adds the specified header to the request.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public HttpRequest WithHeader(string name, string value)
        {
            Headers.Add(name, value);
            
            return this;
        }
    }
}
