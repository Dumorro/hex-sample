using System;
using System.Collections.Generic;
using System.Text;

namespace Hex.Event.Core.Domain.Entities.Dtos
{
    public class SubscribeInputDto
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public string Email { get; set; }
    }
}
