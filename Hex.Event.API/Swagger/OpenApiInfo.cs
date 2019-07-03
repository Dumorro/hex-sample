using Swashbuckle.AspNetCore.Swagger;

namespace Hex.Event.API
{
    internal class OpenApiInfo : Info
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }
}