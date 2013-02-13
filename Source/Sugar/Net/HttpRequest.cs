using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Sugar.Net
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
            Retries = 3;
            Timeout = 30000;
            Verb = HttpVerb.Get;
            UserAgent = UserAgent.Firefox();
            Headers = new NameValueCollection();
            Cookies = new CookieContainer();
            Encoding = Encoding.UTF8;
        }

        /// <summary>
        /// Gets or sets the verb.
        /// </summary>
        /// <value>
        /// The verb.
        /// </value>
        public HttpVerb Verb { get; set; }

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
        public UserAgent UserAgent { get; set; }

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
        /// Gets or sets a value indicating whether [use proxy].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use proxy]; otherwise, <c>false</c>.
        /// </value>
        public bool UseProxy { get; set; }

        /// <summary>
        /// Gets or sets the proxy address.
        /// </summary>
        /// <value>
        /// The proxy address.
        /// </value>
        public string ProxyAddress { get; set; }

        /// <summary>
        /// Gets or sets the proxy port.
        /// </summary>
        /// <value>
        /// The proxy port.
        /// </value>
        public int ProxyPort { get; set; }

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
        /// Gets the cookies.
        /// </summary>
        public CookieContainer Cookies { get; set; }

        /// <summary>
        /// Gets or sets the referer.
        /// </summary>
        /// <value>
        /// The referer.
        /// </value>
        public string Referer { get; set; }

        /// <summary>
        /// Gets or sets the accept.
        /// </summary>
        /// <value>
        /// The accept.
        /// </value>
        public string Accept { get; set; }

        /// <summary>
        /// Gets or sets the encoding.
        /// </summary>
        /// <value>
        /// The encoding.
        /// </value>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Converts this instance to a <see cref="WebRequest"/>
        /// </summary>
        /// <returns></returns>
        public WebRequest ToWebRequest()
        {
            var request = (HttpWebRequest)WebRequest.Create(Url);

            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Method = Verb.ToString().ToUpper();
            request.Timeout = Timeout;
            if (UserAgent != null) request.UserAgent = UserAgent.ToString();
            request.ContentType = ContentType;
            request.Referer = Referer;
            
            if (UseProxy)
            {
                request.Proxy = new WebProxy(ProxyAddress, ProxyPort);
            }
            else
            {
                request.Proxy = WebRequest.DefaultWebProxy; // force default proxy
            }

            if (!string.IsNullOrWhiteSpace(Accept)) request.Accept = Accept;
            request.Headers.Add(Headers);
            request.CookieContainer = Cookies;

            ServicePointManager.ServerCertificateValidationCallback += delegate { return true; }; // to allow HTTPS
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3; // force ssl over tls

            if (UseAuthentication)
            {
                if (UseBasicAuthentication)
                {
                    var header = string.Concat(Username, ":", Password);

                    var encoded = Convert.ToBase64String(Encoding.Default.GetBytes(header));

                    request.Headers["Authorization"] = "Basic " + encoded;
                }
                else
                {
                    request.Credentials = new NetworkCredential(Username, Password);
                }
            }

            return request;
        }     
    }
}
