using Domain.Entities;

namespace Domain.Interfaces.ClienteContracts
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente? FindByCpf(string cpf);
    }
}
