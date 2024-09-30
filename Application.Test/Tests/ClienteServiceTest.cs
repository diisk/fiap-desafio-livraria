using Application.Services;
using Application.Test.Fixtures;
using Domain.Entities;
using Domain.Interfaces.ClienteContracts;
using Moq;
using System.ComponentModel.DataAnnotations;

namespace Application.Test.Tests
{
    public class ClienteServiceTest : IClassFixture<ClienteFixture>
    {
        private readonly ClienteFixture fixture;

        public ClienteServiceTest(ClienteFixture fixture)
        {
            this.fixture = fixture;
        }

        [Theory]
        [InlineData("")]
        [InlineData("asdfasdf")]
        [InlineData("000.000.000-00")]
        public void CadastrarCliente_QuandoCpfInvalido_DeveLancarExcecao(string cpf)
        {
            //GIVEN
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;
            cliente.Cpf = cpf;

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var exception = Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));
            
            //THEN
            var errors = new string[]{ "Cpf obrigatório", "O cpf deve conter 11 digitos" };
            Assert.Contains(errors, e => exception.Message.Contains(e));
        }

        [Fact]
        public void CadastrarCliente_QuandoNomeEmBranco_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;
            cliente.NomeCompleto = "";

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var exception = Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));

            //THEN
            var errors = new List<string>() { "Nome completo obrigatório" };
            Assert.Contains(errors, e => exception.Message.Contains(e));


        }

        [Theory]
        [InlineData("")]
        [InlineData("asdfasdf")]
        [InlineData("0000000")]
        [InlineData("000000000")]
        public void CadastrarCliente_QuandoCepInvalido_DeveLancarExcecao(string cep)
        {
            //GIVEN
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;
            cliente.Endereco.Cep = cep;

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var exception = Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));

            //THEN
            var errors = new string[] { "Cep obrigatório", "O cep deve conter 8 digitos" };
            Assert.Contains(errors, e => exception.Message.Contains(e));
        }

        [Theory]
        [InlineData("")]
        [InlineData("asdfasdf")]
        [InlineData("159746248")]
        [InlineData("478512369547")]
        public void CadastrarCliente_QuandoNumeroTelefoneInvalido_DeveLancarExcecao(string telefone)
        {
            //GIVEN
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;
            cliente.Telefone.Numero = telefone;

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var exception = Assert.Throws<ValidationException>(() => clienteService.CadastrarCliente(cliente));

            //THEN
            var errors = new string[] { "Número obrigatório", "O número deve conter entre 10 e 11 digitos" };
            Assert.Contains(errors, e => exception.Message.Contains(e));
        }

        [Fact]
        public void CadastrarCliente_QuandoCpfJaExiste_DeveLancarExcecao()
        {
            //GIVEN
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;

            mockRepository.Setup(repo => repo.FindByCpf(cliente.Cpf)).Returns(cliente);

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var exception = Assert.Throws<Exception>(() => clienteService.CadastrarCliente(cliente));

            //THEN
            var errors = new string[] { "Já existe um cliente com esse cpf!" };
            Assert.Contains(errors, e => exception.Message.Contains(e));
        }

        [Fact]
        public void CadastrarCliente_QuandoDadosCorretos_DeveRetornarNovoId()
        {
            //GIVEN
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;

            Cliente clienteRetorno = fixture.ClienteValido;
            clienteRetorno.ID = 1;

            mockRepository.Setup(repo => repo.Save(cliente)).Returns(clienteRetorno);

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var retorno = clienteService.CadastrarCliente(cliente);

            //THEN
            Assert.Equal(retorno.ID, clienteRetorno.ID);
        }

        [Fact]
        public void BuscarCliente_QuandoIdNaoExiste_DeveLancarExcecao()
        {
            //GIVEN
            int idCliente = 5;
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;

            mockRepository.Setup(repo => repo.FindById(idCliente)).Returns<Cliente>(null);

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var exception = Assert.Throws<Exception>(() => clienteService.BuscarCliente(idCliente));

            //THEN
            var errors = new string[] { "Cliente não encontrado" };
            Assert.Contains(errors, e => exception.Message.Contains(e));
        }

        [Fact]
        public void BuscarCliente_QuandoIdExiste_DeveRetornarCliente()
        {
            //GIVEN
            int idCliente = 5;
            var mockRepository = new Mock<IClienteRepository>();

            Cliente cliente = fixture.ClienteValido;
            cliente.ID = idCliente;

            mockRepository.Setup(repo => repo.FindById(idCliente)).Returns(cliente);

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var retorno = clienteService.BuscarCliente(idCliente);

            //THEN
            Assert.Equal(retorno.ID, idCliente);
        }

        [Fact]
        public void ListarClientes_QuandoClientesExistem_DeveRetornarListaClientes()
        {
            //GIVEN
            List<Cliente> clientes = new List<Cliente>();
            for (int i = 0; i < 10; i++)
            {
                Cliente cliente = fixture.ClienteValido;
                cliente.ID = i;
                clientes.Add(cliente);
            }
            var mockRepository = new Mock<IClienteRepository>();

            mockRepository.Setup(repo => repo.FindAll()).Returns(clientes);

            var clienteService = new ClienteService(mockRepository.Object);

            //WHEN
            var retorno = clienteService.ListarClientes();

            //THEN
            Assert.True(clientes.Count==retorno.Count&&clientes.All(c=>retorno.Contains(c)));
        }

    }
}