using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        public LivroRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }

        public ICollection<Livro> FindAllAvailables()
        {
            var livros = onlyReadDbSet
                .Include(l => l.ClientesAlugando)
                .Include(e => e.Estoque)
                .Where(l => l.Estoque.Quantidade > l.ClientesAlugando.Count)
                .Select(l=>RemoveCyclicalDependency(l))
                .ToList();
            return livros;
        }

        private Livro RemoveCyclicalDependency(Livro livro)
        {
            livro.Estoque.Livro = null;
            livro.ClientesAlugando = livro.ClientesAlugando.Select(c => {
                c.LivrosAlugados = null;
                c.Telefone = null;
                c.Endereco = null;
                return c;
            }).ToList();
            return livro;
        }
    }
}
