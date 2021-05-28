﻿using System.Threading.Tasks;
using MyWebServer.Server;

namespace MyWebServer
{
    public class StartUp
    {
        public static async Task Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1", 9090);

            await server.Start();
        }
    }
}
