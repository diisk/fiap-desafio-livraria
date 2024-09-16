using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Telefones")]
    public class Telefone:EntityBase
    {
        public required int CodigoArea { get; set; }
        public required string Numero { get; set; }
        public required Cliente Cliente { get; set; }
    }
}
