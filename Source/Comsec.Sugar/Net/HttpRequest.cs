using System.Web;

namespace Comsec.Lib.Net
{
    /// <summary>
    /// Represents a request to download a file from the internet
    /// </summary>
    public class HttpRequest
    {
        public HttpRequest()
        {
            UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; pl; rv:1.9.1) Gecko/20090624 Firefox/3.5 (.NET CLR 3.5.30729)";

            Retries = 3;
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
        /// Gets or sets the user agent.
        /// </summary>
        /// <value>The user agent.</value>
        public string UserAgent { get; set; }

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
    }
}
