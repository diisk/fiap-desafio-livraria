using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Enderecos")]
    public class Endereco : EntityBase
    {
        [RegularExpression(@"^\d{8}$",ErrorMessage = "O cep deve conter 8 digitos")]
        [Required(ErrorMessage = "Cep obrigatório")]
        public required string Cep { get; set; }
        public string? Complemento { get; set; }
        public required int Numero { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
