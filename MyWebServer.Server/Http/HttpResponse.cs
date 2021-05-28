namespace MyWebServer.Server.Http
{
    public class HttpResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpHeaderCollection Headers { get; set; } = new();
    }
}
