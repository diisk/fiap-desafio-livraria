using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }
    }
}
