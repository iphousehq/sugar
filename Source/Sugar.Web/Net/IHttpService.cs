using System.Net;
using System.Text;
using Sugar.Mime;

namespace Sugar.Net
{
    /// <summary>
    /// Interface to define access to downloading content over the internet
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Downloads the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        HttpResponse Download(HttpRequest request);

        /// <summary>
        /// Downloads the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        HttpResponse Download(string url, HttpVerb verb = HttpVerb.Get, string agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null, Encoding encoding = null);

        /// <summary>
        /// Builds a HTTP request from the given arguments.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        HttpRequest Build(string url, HttpVerb verb = HttpVerb.Get, string agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null, Encoding encoding = null);

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        HttpResponse Get(string url, string agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null, Encoding encoding = null);

        /// <summary>
        /// POSTs to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        HttpResponse Post(string url, string agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null, Encoding encoding = null);

        /// <summary>
        /// Gets the HEAD of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="accept">The accept.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        HttpResponse Head(string url, string agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null, Encoding encoding = null);

        /// <summary>
        /// Creates an <see cref="HttpQuery"/> object.
        /// </summary>
        /// <returns></returns>
        HttpQuery Query();
    }
}
