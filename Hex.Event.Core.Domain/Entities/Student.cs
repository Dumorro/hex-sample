using Hex.Event.Core.Domain.Entities.Base;
using System;

namespace Hex.Event.Core.Domain.Entities
{
    public class Student : Entity<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
