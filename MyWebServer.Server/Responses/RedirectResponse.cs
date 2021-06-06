using MyWebServer.Server.Http;

namespace MyWebServer.Server.Responses
{
    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string location)
            : base(HttpStatusCode.Found)
            => this.Headers.Add("Location", location);
    }
}
