using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Web;

namespace Sugar.Net
{
    /// <summary>
    /// Represents an internet URL
    /// </summary>
    public class Url
    {
        protected readonly Uri Uri;
        protected string domain;

        /// <summary>
        /// Initializes a new instance of the <see cref="Url"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public Url(string url)
        {
            Query = new NameValueCollection();

            Uri.TryCreate(url, UriKind.Absolute, out Uri);

            if (Uri != null)
            {
                Query = HttpUtility.ParseQueryString(Uri.Query);
                Fragment = Uri.Fragment;
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
                return Uri != null;
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

                    if (Uri != null)
                    {
                        try
                        {
                            var host = Uri.Host;

                            if (!Uri.IsDefaultPort) host += ":" + Uri.Port;

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
                if (Uri == null) return string.Empty;

                return Uri.Scheme + "://" + Domain;
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
            return Uri == null ? string.Empty : Uri.OriginalString.Trim();
        }

        /// <summary>
        /// Convert this Url to a string including the updated query and fragment.
        /// </summary>
        /// <returns></returns>
        public string ToStringWithQueryAndFragment()
        {
            var builder = new UriBuilder(Uri)
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
                if (Uri == null) return string.Empty;

                var page = Uri.AbsolutePath;

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
                if (Uri == null) return string.Empty;

                var page = Uri.Segments[Uri.Segments.Length - 1];

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
            get { return string.Format("{0}{1}", FullPage, Uri.Query); }
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get
            {
                if (Uri == null) return string.Empty;

                var path = "/";

                foreach (var segment in Uri.Segments)
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

                if (Uri.Host.Length > 0)
                {
                    Match match = Regex.Match(Uri.AbsoluteUri, @"^((http[s]?|ftp):\/)?\/?([^:\/\s]+)((\/\w+)*\/)([\w\-\.]+[^#?\s]+)(.*)?(#[\w\-]+)?$",
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
