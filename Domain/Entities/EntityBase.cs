using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int ID { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Updated { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
