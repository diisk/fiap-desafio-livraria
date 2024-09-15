using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Livros")]
    public class Livro:EntityBase
    {
        public required string Nome { get; set; }
        public required string Autor { get; set; }
        public required string Editora { get; set; }
    }
}
