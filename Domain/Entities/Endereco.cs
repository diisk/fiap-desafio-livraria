using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Enderecos")]
    public class Endereco : EntityBase
    {
        public required string Cep { get; set; }
        public string? Complemento { get; set; }
        public required int Numero { get; set; }


    }
}
