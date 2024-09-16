using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Livros")]
    public class Livro:EntityBase
    {
        public required string Nome { get; set; }
        public required string Autor { get; set; }
        public required string Editora { get; set; }

        public required Estoque Estoque { get; set; }
        public required ICollection<Cliente> ClientesAlugando { get; set; } = new List<Cliente>();
    }
}
