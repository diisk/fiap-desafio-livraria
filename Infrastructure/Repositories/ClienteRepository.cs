using Domain.Entities;
using Domain.Interfaces.ClienteContracts;
using Infrastructure.DbContexts;

namespace Infrastructure.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(OnlyWriteDbContext onlyWriteDbContext, OnlyReadDbContext onlyReadDbContext) : base(onlyWriteDbContext, onlyReadDbContext)
        {
        }

        public Cliente? FindByCpf(string cpf)
        {
            return onlyReadDbSet.FirstOrDefault(cliente=>cliente.Cpf==cpf);
        }
    }
}
