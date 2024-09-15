using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Telefones")]
    public class Telefone:EntityBase
    {
        public required int CodigoArea { get; set; }
        public required string Numero { get; set; }
    }
}
