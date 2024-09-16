using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Enderecos")]
    public class Endereco : EntityBase
    {
        public required string Cep { get; set; }
        public string? Complemento { get; set; }
        public required int Numero { get; set; }

        public required Cliente Cliente { get; set; }
    }
}
