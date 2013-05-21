using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Sugar.Net
{
    /// <summary>
    /// Represents an internet URL
    /// </summary>
    public class Url
    {
        private readonly Uri uri;
        private string domain;
        private string subdomain;

        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public Url(string url)
        {
            Query = new NameValueCollection();

            Uri.TryCreate(url, UriKind.Absolute, out uri);

            if (uri != null)
            {
                Query = HttpUtility.ParseQueryString(uri.Query);
                Fragment = uri.Fragment;
            }
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
        /// Gets the query.
        /// </summary>
        /// <value>
        /// The query.
        /// </value>
        public NameValueCollection Query { get; private set; }

        /// <summary>
        /// Gets or sets the fragment.
        /// </summary>
        /// <value>
        /// The fragment.
        /// </value>
        public string Fragment { get; set; }

        /// <summary>
        /// Adds to query.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public Url AddToQuery(string key, object value)
        {
            Query.Add(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Removes from query.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Url RemoveFromQuery(string key)
        {
            Query.Remove(key);
            return this;
        }

        /// <summary>
        /// Gets the domain.
        /// </summary>
        /// <value>The domain.</value>
        public string Domain
        {
            get
            {
                if (string.IsNullOrEmpty(domain))
                {
                    domain = string.Empty;

                    if (uri != null)
                    {
                        try
                        {
                            var host = uri.Host;

                            if (!uri.IsDefaultPort) host += ":" + uri.Port;

                            domain = host.ToLower();
                        }
                        catch
                        {
                            domain = string.Empty;
                        }
                    }
                }

                return domain;
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
            get { return Domain.Replace("www.", string.Empty); }
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
        /// Convert this Url to a string including the updated query and fragment.
        /// </summary>
        /// <returns></returns>
        public string ToStringWithQueryAndFragment()
        {
            var builder = new UriBuilder(uri)
                              {
                                  Query = Query.ToString(),
                                  Fragment = Fragment
                              };

            return builder.Uri.ToString();
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
            get { return string.Format("{0}{1}", FullPage, uri.Query); }
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
        /// Equalses the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public bool Equals(string url)
        {
            return string.Compare(url, ToString(), true) == 0;
        }

        /// <summary>
        /// Gets the sub domain.
        /// </summary>
        /// <value>The sub domain.</value>
        public string SubDomain
        {
            get
            {
                if (string.IsNullOrEmpty(subdomain))
                {
                    subdomain = string.Empty;

                    if (!string.IsNullOrEmpty(DomainSansWww))
                    {
                        var matchedTlds = CommonTlds.Instance.Tlds.Where(x => DomainSansWww.EndsWith(x, StringComparison.OrdinalIgnoreCase)).ToList();

                        var matchedTld = string.Empty;

                        if (matchedTlds.Count > 0)
                        {
                            foreach (var tld in matchedTlds)
                            {
                                matchedTld = matchedTld.Length > tld.Length ? matchedTld : tld;
                            }
                        }

                        var domainWithoutTld = DomainSansWww
                            .Replace(matchedTld, string.Empty)
                            .Trim('.');

                        var parts = domainWithoutTld.Split('.');

                        subdomain = parts.Take(parts.Length - 1).Join(".");
                    }
                }

                return subdomain;
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
                return HasSubDomain ? DomainSansWww.Replace(SubDomain + ".", string.Empty) : DomainSansWww;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has sub domain.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has sub domain; otherwise, <c>false</c>.
        /// </value>
        public bool HasSubDomain
        {
            get
            {
                return !string.IsNullOrEmpty(SubDomain);
            }
        }

        /// <summary>
        /// Gets the TLD.
        /// </summary>
        /// <value>
        /// The TLD.
        /// </value>
        public string Tld
        {
            get
            {
                var tld = "";

                if (uri.Host.Length > 0)
                {
                    var match = Regex.Match(uri.AbsoluteUri, @"^((http[s]?|ftp):\/)?\/?([^:\/\s]+)((\/\w+)*\/)([\w\-\.]+[^#?\s]+)(.*)?(#[\w\-]+)?$", RegexOptions.IgnoreCase);

                    if (match.Success)
                    {
                        var host = match.Groups[3].Value;

                        var hosts = host.Split('.');

                        tld = "." + hosts[hosts.Length - 1];
                    }
                }

                return tld;
            }
        }
    }
}
