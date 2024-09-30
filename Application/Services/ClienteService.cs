using Domain.Entities;
using Domain.Interfaces.ClienteContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            this.clienteRepository = clienteRepository;
        }

        public Cliente AtualizarCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Cliente BuscarCliente(int id)
        {
            Cliente? cliente = clienteRepository.FindById(id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            return cliente;
        }

        public Cliente CadastrarCliente(Cliente cliente)
        {
            cliente.Validate();

            if (clienteRepository.FindByCpf(cliente.Cpf) != null)
                throw new Exception("Já existe um cliente com esse cpf!");

            return clienteRepository.Save(cliente);
        }

        public void DeletarCliente(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> ListarClientes()
        {
            return clienteRepository.FindAll().ToList();
        }
    }
}
