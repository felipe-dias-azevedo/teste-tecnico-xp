using FelipeAzevedo.TesteXP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.Repositories.Cliente;
using FelipeAzevedo.TesteXP.ViewModels.Cadastro;

namespace FelipeAzevedo.TesteXP.Business
{
    public class CadastroBusiness : ICadastroBusiness
    {
        private readonly IClienteRepository _clienteRepository;

        public CadastroBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        
        public async Task<string> CadastrarCliente(CadastroClienteViewModel cadastroCliente)
        {
            var id = Guid.NewGuid().ToString();

            var cliente = new ClienteModel
            {
                Id = id,
            };

            await _clienteRepository.Inserir(cliente);

            return id;
        }

        public async Task<ClienteEnderecoViewModel?> ObterCliente(string cpf)
        {
            var cliente = await _clienteRepository.ObterPorCpf(cpf);

            if (cliente == null)
            {
                return null;
            }

            return new ClienteEnderecoViewModel
            {
                
            };
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterClientes()
        {
            var clientes = await _clienteRepository.Obter();

            return clientes.Select(x => new ClienteViewModel());
        }
    }
}
