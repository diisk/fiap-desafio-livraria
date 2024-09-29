using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Clientes")]
    public class Cliente : EntityBase
    {

        [Required(ErrorMessage = "Nome completo obrigatório")]
        public required string NomeCompleto { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "O cpf deve conter 11 digitos")]
        [Required(ErrorMessage = "Cpf obrigatório")]
        public required string Cpf { get; set; }

        public virtual required Endereco Endereco { get; set; }
        public virtual required Telefone Telefone { get; set; }

        public virtual ICollection<Livro> LivrosAlugados { get; set; } = new List<Livro>();

        public override void Validate()
        {
            base.Validate();
            Endereco.Validate();
            Telefone.Validate();
        }
    }
}
