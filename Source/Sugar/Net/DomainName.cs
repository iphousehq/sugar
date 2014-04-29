namespace Sugar.Net
{
    /// <summary>
    /// Helper class to extract the domain name and subdomain from a domain name.
    /// </summary>
    public class DomainName
    {
        private readonly string domainName;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainName"/> class.
        /// </summary>
        /// <param name="domainName">The domain name (e.g. wwww.domainname.com).</param>
        public DomainName(string domainName)
        {
            this.domainName = domainName;
        }

        /// <summary>
        /// Gets the domain sans sub domain.
        /// </summary>
        /// <value>The domain sans sub domain.</value>
        public string DomainSansSubDomain
        {
            get
            {
                return string.IsNullOrEmpty(SubDomain) ? domainName : domainName.Replace(SubDomain + ".", string.Empty);
            }
        }

        /// <summary>
        /// Gets the sub domain.
        /// </summary>
        /// <value>
        /// The sub domain.
        /// </value>
        public string SubDomain
        {
            get
            {
                var subDomain = string.Empty;

                // HACK: this needs to be sorted out
                var parts = domainName.Split('.');

                var count = 0;

                for (var i = parts.Length - 1; i >= parts.Length - 2; i--)
                {
                    if (i < 0) break;

                    if (parts[i].Length < 3)
                    {
                        count++;
                    }
                }

                var max = parts.Length - 2;

                if (count == 2)
                {
                    max = parts.Length - 3;
                }

                for (var i = 0; i < max; i++)
                {
                    if (!string.IsNullOrEmpty(subDomain)) subDomain += ".";

                    subDomain += parts[i];
                }


                return subDomain;
            }

        }
    }
}
