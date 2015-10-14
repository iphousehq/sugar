using System;
using System.Net;

namespace Sugar.Net
{
    /// <summary>
    /// Object to hold details of a proxy server used for a <see cref="HttpRequest"/>.
    /// </summary>
    public class HttpProxy
    {
        /// <summary>
        /// Gets or sets the hostname.
        /// </summary>
        /// <value>
        /// The hostname.
        /// </value>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether authentication is required to use
        /// this proxy.
        /// </summary>
        /// <value>
        /// <c>true</c> if authentication required; otherwise, <c>false</c>.
        /// </value>
        public bool AuthenticationRequired { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Returns a <see cref="WebProxy"/> representation of this instance.
        /// </summary>
        /// <returns></returns>
        public WebProxy ToWebProxy()
        {
            WebProxy proxy;

            if (AuthenticationRequired)
            {
                var credentials = new NetworkCredential(UserName, Password);
                var bypass = new string[0];
                var hostname = new Uri(string.Concat("http://", Hostname, ":", Port));

                proxy = new WebProxy(hostname, true, bypass, credentials);      
            }
            else
            {
                proxy = new WebProxy(Hostname, Port);
            }

            return proxy;
        }
    }
}
