using MyWebServer.Server;
using MyWebServer.Server.Responses;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class StartUp
    {
        public static async Task Main(string[] args)
            => await new HttpServer(
                    routes => routes
                        .MapGet("/", new TextResponse("Hello from Index page."))
                        .MapGet("/Cats", new HtmlResponse("<h1>Hello from the cats.</h1>")))
                .Start();
    }
}
