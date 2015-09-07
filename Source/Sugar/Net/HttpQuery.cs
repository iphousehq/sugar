using System.Net;

namespace Sugar.Net
{
    /// <summary>
    /// Object-chained query to download multiple HTTP requests
    /// </summary>
    public class HttpQuery
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpQuery"/> class.
        /// </summary>
        /// <param name="httpService">The HTTP service.</param>
        public HttpQuery(IHttpService httpService)
        {
            HttpService = httpService;
        }

        /// <summary>
        /// Gets or sets the HTTP service.
        /// </summary>
        /// <value>
        /// The HTTP service.
        /// </value>
        public IHttpService HttpService { get; set; }

        /// <summary>
        /// Gets or sets the request.
        /// </summary>
        /// <value>
        /// The request.
        /// </value>
        public HttpRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the response.
        /// </summary>
        /// <value>
        /// The response.
        /// </value>
        public HttpResponse Response { get; set; }

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="agent">The agent.</param>
        /// <param name="cookies">The cookies.</param>
        /// <param name="persistState">if set to <c>true</c> persist the state (cookes, UserAgent and referring URL) from any previous
        /// requests.</param>
        /// <param name="referer">The referer URL.</param>
        /// <param name="retries">The number of retry attemps.</param>
        /// <param name="timeout">The timeout in milliseconds.</param>
        /// <returns></returns>
        public virtual HttpQuery Get(string url, UserAgent agent = null, CookieContainer cookies = null, bool persistState = true, string referer = null, int retries = 0, int timeout = 2500)
        {
            Request = HttpService.Build(url, HttpVerb.Get, agent, cookies, referer, retries, timeout);

            // Persist cookies across requests
            if (Response != null && persistState)
            {
                Request.Referer = Response.Url;
                Request.Cookies = Response.Cookies;
            }

            Response = HttpService.Download(Request);

            return this;
        }

    }
}
