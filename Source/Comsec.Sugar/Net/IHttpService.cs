namespace Comsec.Lib.Net
{
    /// <summary>
    /// Interface to define access to downloading content over the internet
    /// </summary>
    public interface IHttpService
    {
        /// <summary>
        /// Gets the contents of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        HttpResponse Get(string url);

        /// <summary>
        /// Gets the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="userAgent">The user agent.</param>
        /// <returns></returns>
        HttpResponse Get(string url, string userAgent);

        /// <summary>
        /// Gets the content specified in the given request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        HttpResponse Get(HttpRequest request);
    }
}
