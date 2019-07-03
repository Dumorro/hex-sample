using System.ComponentModel.DataAnnotations;

namespace Hex.Event.Core.Domain.Entities.Base
{
    public class Entity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
