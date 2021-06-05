using System;
using System.Collections.Generic;
using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable()
            => this.routes = new()
            {
                [HttpMethod.Get] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Put] = new(),
                [HttpMethod.Delete] = new(),
            };

        public IRoutingTable Map(HttpMethod path, string url, HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[path][url] = response;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
            => this.Map(HttpMethod.Get, path, response);

        public IRoutingTable MapPost(string path, HttpResponse response)
            => this.Map(HttpMethod.Post, path, response);

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var requestMethod = request.Method;
            var requestUrl = request.Path;

            if (!this.routes.ContainsKey(requestMethod)
                || !this.routes[requestMethod].ContainsKey(requestUrl))
            {
                return new NotFoundResponse();
            }

            return this.routes[requestMethod][requestUrl];
        }
    }
}
