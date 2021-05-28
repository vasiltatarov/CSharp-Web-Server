namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {
        private const string NewLine = "\r\n";

        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public HttpHeaderCollection Headers { get; set; } = new();

        public string Body { get; private set; }

        public static HttpRequest Parse(string request)
        {

        }
    }
}
