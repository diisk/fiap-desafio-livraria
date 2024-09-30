using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ClienteContracts
{
    public interface IClienteService
    {
        public Cliente CadastrarCliente(Cliente cliente);
        public Cliente BuscarCliente(int id);
        public List<Cliente> ListarClientes();
        public void DeletarCliente(int id);
        public Cliente AtualizarCliente(Cliente cliente);
    }
}
