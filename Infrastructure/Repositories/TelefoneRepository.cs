using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class TelefoneRepository : BaseRepository<Telefone>, ITelefoneRepository
    {
        public TelefoneRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }
    }
}
