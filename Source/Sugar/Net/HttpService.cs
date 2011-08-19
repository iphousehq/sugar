using System;
using System.IO;
using System.Net;
using System.Text;

namespace Sugar.Net
{
    /// <summary>
    /// Class to download content from the internet
    /// </summary>
    public class HttpService : IHttpService
    {
        public const string Ie6UserAgent = "Mozilla/4.0 (compatible; MSIE 6.01; Windows NT 6.0)Mozilla/4.0 (compatible; MSIE 6.01; Windows NT 6.0)";

        /// <summary>
        /// Gets the contents of the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        public HttpResponse Get(string url)
        {
            return Get(new HttpRequest { Url = url });
        }

        public HttpResponse Get(string url, string userAgent)
        {
            return Get(new HttpRequest { Url = url, UserAgent = userAgent });
        }

        /// <summary>
        /// Gets the content specified in the given request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public HttpResponse Get(HttpRequest request)
        {
            return Retry.This(() => GetAction(request, "GET"), request.Retries, 5000);
        }

        public HttpResponse Post(HttpRequest request)
        {
            return Retry.This(() => GetAction(request, "POST"), request.Retries, 5000);
        }

        private static HttpResponse GetAction(HttpRequest request, string action)
        {
            var result = new HttpResponse { Url = request.Url };

            try
            {
                var webRequest = (HttpWebRequest)WebRequest.Create(request.Url);

                webRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                webRequest.Method = action;
                webRequest.Timeout = request.Timeout;
                webRequest.UserAgent = request.UserAgent;
                webRequest.ContentType = request.ContentType;
                ServicePointManager.ServerCertificateValidationCallback += delegate { return true; }; // to allow HTTPS

                webRequest.Headers.Add(request.Headers);

                if (request.UseAuthentication)
                {
                    if (request.UseBasicAuthentication)
                    {
                        var header = string.Concat(request.Username, ":", request.Password);

                        var encoded = Convert.ToBase64String(Encoding.Default.GetBytes(header));

                        webRequest.Headers["Authorization"] = "Basic " + encoded;
                    }
                    else
                    {
                        webRequest.Credentials = new NetworkCredential(request.Username, request.Password);
                    }
                }

                if (action == "POST")
                {
                    using (var stream = webRequest.GetRequestStream())
                    {
                        var encoder = new UTF8Encoding();

                        byte[] data = encoder.GetBytes(request.Data);

                        stream.Write(data, 0, data.Length);

                        stream.Close();
                    }
                }

                using (var response = webRequest.GetResponse())
                {
                    using (var stream = response.GetResponseStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            var buffer = new byte[2048];

                            int bytesRead;

                            do
                            {
                                bytesRead = stream.Read(buffer, 0, buffer.Length);

                                memoryStream.Write(buffer, 0, bytesRead);
                            }
                            while (bytesRead != 0);

                            if (memoryStream.Length > 0) result.Bytes = memoryStream.ToArray();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                result.Exception = ex;
            }
            catch (UriFormatException ex)
            {
                result.Exception = ex;
            }
            catch (ArgumentNullException ex)
            {
                result.Exception = ex;
            }
            catch (NullReferenceException ex)
            {
                result.Exception = ex;
            }

            return result;
        }
    }
}
