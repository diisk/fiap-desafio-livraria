using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Clientes")]
    public class Cliente:EntityBase
    {
        public required string NomeCompleto { get; set; }
        public required string Cpf { get; set; }

        public required Endereco Endereco { get; set; }
        public required Telefone Telefone { get; set; }

        public virtual required ICollection<Livro> LivrosAlugados { get; set; } = new List<Livro>();
    }
}
