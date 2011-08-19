namespace Sugar.Net
{
    public class DomainName
    {
        private readonly string domainName;

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
