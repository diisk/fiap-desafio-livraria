using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Estoque")]
    public class Estoque : EntityBase
    {
        public required int Quantidade { get; set; }

        public required Livro Livro { get; set; }
    }
}
