using System.Net;
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
        /// <returns></returns>
        HttpResponse Download(string url, HttpVerb verb = HttpVerb.Get, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null);

        /// <summary>
        /// Builds a HTTP request from the given arguments.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <returns></returns>
        HttpRequest Build(string url, HttpVerb verb = HttpVerb.Get, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null);

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        HttpResponse Get(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500, BaseMime accept = null);

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        HttpResponse Get(string url);

        /// <summary>
        /// POSTs to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        HttpResponse Post(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500);

        /// <summary>
        /// POSTs to the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        HttpResponse Post(string url);

        /// <summary>
        /// Gets the HEAD of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="referer">The referer.</param>
        /// <param name="retries">The retries.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns></returns>
        HttpResponse Head(string url, UserAgent agent = null, CookieContainer cookies = null, string referer = "", int retries = 0, int timeout = 2500);

        /// <summary>
        /// Gets the HEAD of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        HttpResponse Head(string url);

        /// <summary>
        /// Creates an <see cref="HttpQuery"/> object.
        /// </summary>
        /// <returns></returns>
        HttpQuery Query();
    }
}
