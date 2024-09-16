using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }
    }
}
