using System;
using System.Text.RegularExpressions;

namespace Comsec.Sugar.Net
{
    /// <summary>
    /// Represents an internet URL
    /// </summary>
    public class Url
    {
        private readonly Uri uri;

        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public Url(string url)
        {
            Uri.TryCreate(url, UriKind.Absolute, out uri);
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value><c>true</c> if this instance is valid; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get
            {
                return uri != null;
            }
        }

        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public string Domain
        {
            get
            {
                if (uri == null) return string.Empty;

                try
                {
                    var host = uri.Host;

                    if (!uri.IsDefaultPort) host += ":" + uri.Port;

                    return host.ToLower();
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the domain with protocol.
        /// </summary>
        /// <value>The domain with protocol.</value>
        public string DomainWithProtocol
        {
            get
            {
                if (uri == null) return string.Empty;

                return uri.Scheme + "://" + Domain;
            }
        }

        /// <summary>
        /// Gets the domain sans the WWW prefix.
        /// </summary>
        /// <value>The domain sans WWW.</value>
        public string DomainSansWww
        {
            get
            {
                var domain = string.Empty;

                if (uri != null)
                {
                    domain = Domain;

                    if (domain.StartsWith("www.")) domain = domain.Replace("www.", string.Empty);
                }

                return domain;
            }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return uri == null ? string.Empty : uri.OriginalString.Trim();
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <value>The page.</value>
        public string FullPage
        {
            get
            {
                if (uri == null) return string.Empty;

                var page = uri.AbsolutePath;

                if (page == "/") page = "Site Root";

                return page;
            }
        }

        /// <summary>
        /// Gets the page.
        /// </summary>
        /// <value>The page.</value>
        public string Page
        {
            get
            {
                if (uri == null) return string.Empty;

                var page = uri.Segments[uri.Segments.Length - 1];

                if (page == "/") page = "Site Root";

                return page;
            }
        }

        /// <summary>
        /// Gets the full page with query string.
        /// </summary>
        /// <value>The full page with query string.</value>
        public string FullPageWithQueryString
        {
            get
            {
                if (uri == null) return string.Empty;

                var page = uri.AbsolutePath + uri.Query;

                if (page == "/") page = "Site Root";

                return page;

            }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get
            {
                if (uri == null) return string.Empty;

                var path = "/";

                foreach (var segment in uri.Segments)
                {
                    if (segment == "/")
                    {
                    }
                    else if (!segment.Contains("."))
                    {
                        path += segment;
                    }
                    else
                    {
                        break;
                    }
                }

                return path;
            }
        }

        /// <summary>
        /// Gets the domain sans sub domain.
        /// </summary>
        /// <value>The domain sans sub domain.</value>
        public string DomainSansSubDomain
        {
            get
            {
                return string.IsNullOrEmpty(SubDomain) ? Domain : Domain.Replace(SubDomain + ".", string.Empty);
            }
        }

        /// <summary>
        /// Gets the sub domain.
        /// </summary>
        /// <value>The sub domain.</value>
        public string SubDomain
        {
            get
            {
                var subDomain = string.Empty;

                if (uri != null)
                {

                    // HACK: this needs to be sorted out
                    var parts = uri.Host.Split('.');

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
                }

                return subDomain;
            }

        }

        /// <summary>
        /// Equalses the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public bool Equals(string url)
        {
            return string.Compare(url, ToString(), true) == 0;
        }

        public string Tld
        {
            get
            {
                var tld = "";

                if (uri.Host.Length > 0)
                {
                    Match match = Regex.Match(uri.AbsoluteUri, @"^((http[s]?|ftp):\/)?\/?([^:\/\s]+)((\/\w+)*\/)([\w\-\.]+[^#?\s]+)(.*)?(#[\w\-]+)?$",
                       RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        string host = match.Groups[3].Value;

                        var hosts = host.Split('.');

                        tld = "." + hosts[hosts.Length - 1];
                    }
                }

                return tld;
            }
        }
    }
}
