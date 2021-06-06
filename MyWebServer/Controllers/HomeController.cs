using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;

namespace MyWebServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request)
            : base(request)
        { }

        public HttpResponse Index() => Text("Hello from Vasko!");

        public HttpResponse LocalRedirect() => Redirect("/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");
    }
}
