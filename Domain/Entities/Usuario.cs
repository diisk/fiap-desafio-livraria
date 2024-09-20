using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Usuario")]
    public class Usuario:EntityBase
    {
        public required string Email { get; set; }
        public required string Senha { get; set; }


    }
}
