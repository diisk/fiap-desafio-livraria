using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class EstoqueRepository : BaseRepository<Estoque>, IEstoqueRepository
    {
        public EstoqueRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }
    }
}
