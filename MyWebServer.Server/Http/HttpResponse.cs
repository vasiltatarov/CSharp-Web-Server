using System;
using System.Collections.Generic;
using System.Text;
using MyWebServer.Server.Common;

namespace MyWebServer.Server.Http
{
    public abstract class HttpResponse
    {
        protected HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.AddHeader("Server", "My Web Server");
            this.AddHeader("Date", $"{DateTime.UtcNow:r}");
        }

        public HttpStatusCode StatusCode { get; protected set; }

        public IDictionary<string, HttpHeader> Headers { get; } = new Dictionary<string, HttpHeader>();

        public IDictionary<string, HttpCookie> Cookies = new Dictionary<string, HttpCookie>();

        public string Content { get; protected set; }

        public void AddHeader(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Headers.Add(name, new HttpHeader(name, value));
        }

        public void AddCookie(string name, string value)
        {
            Guard.AgainstNull(name, nameof(name));
            Guard.AgainstNull(value, nameof(value));

            this.Cookies.Add(name, new HttpCookie(name, value));
        }

        protected void PrepareContent(string content, string contentType)
        {
            var contentLength = Encoding.UTF8.GetByteCount(content).ToString();

            this.AddHeader("Content-Type", contentType);
            this.AddHeader("Content-Length", contentLength);

            this.Content = content;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();
                result.AppendLine(this.Content);
            }

            return result.ToString();
        }
    }
}
