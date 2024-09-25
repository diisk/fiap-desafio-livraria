﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Clientes")]
    public class Cliente : EntityBase
    {

        public required string NomeCompleto { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "O cpf deve conter 11 digitos.")]
        public required string Cpf { get; set; }

        public virtual required Endereco Endereco { get; set; }
        public virtual required Telefone Telefone { get; set; }

        public virtual required ICollection<Livro> LivrosAlugados { get; set; } = new List<Livro>();
    }
}
