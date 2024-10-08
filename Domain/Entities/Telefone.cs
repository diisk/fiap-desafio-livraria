﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Telefones")]
    public class Telefone : EntityBase
    {
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O número deve conter entre 10 e 11 digitos")]
        [Required(ErrorMessage = "Número obrigatório")]
        public required string Numero { get; set; }
        public virtual Cliente? Cliente { get; set; }
    }
}
