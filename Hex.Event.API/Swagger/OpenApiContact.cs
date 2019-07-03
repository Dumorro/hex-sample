using System;
using Swashbuckle.AspNetCore.Swagger;

namespace Hex.Event.API
{
    internal class OpenApiContact : Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri Url { get; set; }
    }
}