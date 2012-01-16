namespace Sugar.Net
{
    /// <summary>
    /// Extension methods for the <see cref="HttpResponse"/>.
    /// </summary>
    public static class HttpResponseExtensions
    {
        /// <summary>
        /// Returns a dynamic representations of this instance's JSON data.
        /// </summary>
        /// <returns></returns>
        public static dynamic ToJson(this HttpResponse response)
        {
            return response.ToString().DecodeJson();
        }
    }
}
