using System.IO;
using System.Linq;
using MyWebServer.Server.Http;

namespace MyWebServer.Server.Responses
{
    public class ViewResponse : HttpResponse
    {
        private const char PathSeparator = '/';

        public ViewResponse(string filePath, string controllerName, object model)
            : base(HttpStatusCode.OK)
        {
            this.GetHtml(filePath, controllerName, model);
        }

        private void GetHtml(string viewName, string controllerName, object model)
        {
            if (!viewName.Contains(PathSeparator))
            {
                viewName = controllerName + PathSeparator + viewName;
            }

            var viewPath = Path.GetFullPath($"./Views/" + viewName.TrimStart(PathSeparator) + ".cshtml");

            if (!File.Exists(viewPath))
            {
                this.PrepareMissingViewError(viewPath);
                return;
            }

            var viewContent = File.ReadAllText(viewPath);

            if (model != null)
            {
                viewContent = this.PopulateModel(viewContent, model);
            }

            this.Content = viewContent;
        }

        private void PrepareMissingViewError(string viewPath)
        {
            this.StatusCode = HttpStatusCode.NotFound;

            var errorMessage = $"View '{viewPath}' was not found.";

            this.Content = errorMessage;
        }

        private string PopulateModel(string viewContent, object model)
        {
            var data = model
                .GetType()
                .GetProperties()
                .Select(pr => new
                {
                    Name = pr.Name,
                    Value = pr.GetValue(model),
                });

            const string openingBrackets = "{{";
            const string closingBrackets = "}}";

            foreach (var entry in data)
            {
                viewContent = viewContent
                    .Replace($"{openingBrackets}{entry.Name}{closingBrackets}", entry.Value.ToString());
            }

            return viewContent;
        }
    }
}
