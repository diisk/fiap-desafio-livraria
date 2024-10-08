﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Estoque")]
    public class Estoque : EntityBase
    {
        public required int Quantidade { get; set; }

        public virtual required Livro Livro { get; set; }
    }
}
