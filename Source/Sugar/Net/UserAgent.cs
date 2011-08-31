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
                    return new UserAgent("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1)");

                case 9:
                    return new UserAgent("Mozilla/4.0 (compatible; MSIE 9.0; Windows NT 6.1)");

                default:
                    throw new ApplicationException("Unsupported IE user agent version: " + version + " - IE 6-9 supported");
            }
        }

        /// <summary>
        /// Returns a Firefox user agent
        /// </summary>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        public static UserAgent Firefox(int version = 5)
        {
            switch (version)
            {
                case 3:
                    return new UserAgent("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.1) Gecko/2008070208 Firefox/3.0.0");

                case 4:
                    return new UserAgent("Mozilla/5.0 (Windows NT 6.1; rv:2.0) Gecko/20110319 Firefox/4.0");

                case 5:
                    return new UserAgent("Mozilla/5.0 (Windows NT 5.0; rv:5.0) Gecko/20100101 Firefox/5.0");

                default:
                    throw new ApplicationException("Unsupported Firefox user agent version: " + version + " - Firefox 6-9 supported");
            }
        }

        /// <summary>
        /// Returns a Google Chrome user agent
        /// </summary>
        /// <returns></returns>
        public static UserAgent Chrome()
        {
            return new UserAgent("Mozilla/5.0 (Windows; U; Windows NT 5.2; en-US) AppleWebKit/534.10 (KHTML, like Gecko) Chrome/13.0.782.43 Safari/535.1");
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
