using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        // Este es el que expones al mundo (seguro)
        public Guid PublicId { get; set; } = Guid.CreateVersion7();// Guid.NewGuid();
    }
}