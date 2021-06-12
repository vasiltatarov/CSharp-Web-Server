using System.Runtime.CompilerServices;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
            => this.Request = request;

        protected HttpRequest Request { get; private init; }

        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string html)
            => new HtmlResponse(html);

        protected HttpResponse Redirect(string location)
            => new RedirectResponse(location);

        protected HttpResponse View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, this.GetType().GetControllerName(), null);

        protected HttpResponse View(string viewName, object model)
            => new ViewResponse(viewName, this.GetType().GetControllerName(), model);
    }
}
