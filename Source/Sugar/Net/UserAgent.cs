using System;

namespace Sugar.Net
{
    /// <summary>
    /// Common browser user agents
    /// </summary>
    public class UserAgent
    {
        private readonly string agentString;

        private UserAgent(string agentString)
        {
            this.agentString = agentString;
        }

        /// <summary>
        /// Returns an Internet Explorer user agent.
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        public static UserAgent InternetExplorer(int version = 6)
        {
            switch (version)
            {
                case 6:
                    return new UserAgent("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0)");

                case 7:
                    return new UserAgent("Mozilla/4.0 (compatible; MSIE 7.0;Windows NT 6.0)");

                case 8:
                    return new UserAgent("Mozilla/4.0 (compatible; MSIEg 8.0; Windows NT 6.1)");

                case 9:
                    return new UserAgent("Mozilla/4.0 (compatible; MSIE 9.0; Windows NT 6.1)");

                case 10:
                    return new UserAgent("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)");

                default:
                    throw new ApplicationException("Unsupported IE user agent version: " + version + " - IE 6-9 supported");
            }
        }

        /// <summary>
        /// Returns a Firefox user agent
        /// </summary>
        /// <returns></returns>
        public static UserAgent Firefox()
        {
            return new UserAgent("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:8.0.1) Gecko/20100101 Firefox/8.0.1");
        }

        /// <summary>
        /// Returns a Google Chrome user agent
        /// </summary>
        /// <returns></returns>
        public static UserAgent Chrome()
        {
            return new UserAgent("Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");
        }

        /// <summary>
        /// Return an iOS 4.3.3 Safari user agent.
        /// </summary>
        /// <returns></returns>
        public static UserAgent Iphone()
        {
            return new UserAgent("Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_3 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8J2 Safari/6533.18.5");
        }

        /// <summary>
        /// Returns a custom user agent
        /// </summary>
        /// <returns></returns>
        public static UserAgent Custom(string userAgent)
        {
            return new UserAgent(userAgent);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return agentString;
        }
    }
}
