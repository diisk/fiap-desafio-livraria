using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
    public class OnlyReadDbContext: DbContext
    {
        private readonly string connectionString;

        public OnlyReadDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Cliente> clienteSet { get; set; }
        public DbSet<Estoque> estoqueSet { get; set; }
        public DbSet<Livro> livroSet { get; set; }
        public DbSet<Telefone> telefoneSet { get; set; }
        public DbSet<Endereco> enderecoSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8,0)));
            }
        }
    }
}
