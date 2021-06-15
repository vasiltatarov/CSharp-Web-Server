using MyWebServer.Server.Http;

namespace MyWebServer.Server.Responses
{
    public class ActionResult : HttpResponse
    {
        public ActionResult(HttpResponse response)
            : base(response.StatusCode)
        {
            this.Response = response;

            this.StatusCode = response.StatusCode;
            this.PrepareHeaders(response);
        }

        public HttpResponse Response { get; set; }

        private void PrepareHeaders(HttpResponse response)
        {
            foreach (var header in response.Headers)
            {
                
            }
        }
    }
}
