using System.Threading.Tasks;
using MyWebServer.Controllers;
using MyWebServer.Server;
using MyWebServer.Server.Http;
using MyWebServer.Server.Results;

namespace MyWebServer
{
    public class StartUp
    {
        public static async Task Main(string[] args)
            => await new HttpServer(
                    routes => routes
                        .MapGet("/", new TextResponse("Hello from Index page."))
                        .MapGet("/Cats", new TextResponse("<h1>Hello from the cats.</h1>", "text/html")))
                .Start();
    }
}
