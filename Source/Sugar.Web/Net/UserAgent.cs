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
                    return new UserAgent("Mozilla/5.0 (compatible; MSIE 7.0;Windows NT 6.0)");

                case 8:
                    return new UserAgent("Mozilla/5.0 (compatible; MSIEg 8.0; Windows NT 6.1)");

                case 9:
                    return new UserAgent("Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1)");

                case 10:
                    return new UserAgent("Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)");

                case 11:
                    return new UserAgent("Mozilla/5.0 (compatible, MSIE 11, Windows NT 6.3; Trident/7.0;  rv:11.0)");

                default:
                    throw new ApplicationException("Unsupported IE user agent version: " + version + " - IE 6-11 supported");
            }
        }

        /// <summary>
        /// Returns a Google Chrome user agent
        /// </summary>
        /// <returns></returns>
        public static UserAgent Chrome()
        {
            return new UserAgent("Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");
        }

        public static UserAgent Edge()
        {
            return new UserAgent("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.246");
        }

        /// <summary>
        /// Returns a Firefox user agent
        /// </summary>
        /// <returns></returns>
        public static UserAgent Firefox()
        {
            return new UserAgent("Mozilla/5.0 (Windows NT 6.1; WOW64; rv:40.0) Gecko/20100101 Firefox/40.1");
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
        /// Returns a Blackberry 9900 user agent.
        /// </summary>
        /// <returns></returns>
        public static UserAgent Blackberry()
        {
            return new UserAgent("Mozilla/5.0 (BlackBerry; U; BlackBerry 9900; en-US) AppleWebKit/534.11+ (KHTML, like Gecko) Version/7.0.0 Mobile Safari/534.11+");
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
