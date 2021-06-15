using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    public class HttpSession
    {
        private Dictionary<string, string> data;

        public HttpSession() => this.data = new Dictionary<string, string>();

        public string Id { get; set; }

        public string this[string key]
        {
            get => this.data[key];
            set => this.data[key] = value;
        }

        public bool ContainsKey(string key)
            => this.data.ContainsKey(key);
    }
}
