using Hex.Event.Core.Domain.Entities.Base;
using System;

namespace Hex.Event.Core.Domain.Entities
{
    public class Course: Entity<int>
    {
        public Course Name { get; set; }
    }
}
