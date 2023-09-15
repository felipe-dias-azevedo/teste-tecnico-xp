using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.Repositories.Cliente;
using FelipeAzevedo.TesteXP.ViewModels.Cadastro;
using FelipeAzevedo.TesteXP.Repositories.Endereco;
using FelipeAzevedo.TesteXP.Adapters;

namespace FelipeAzevedo.TesteXP.Business
{
    public class CadastroBusiness : ICadastroBusiness
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IEnderecoRepository _enderecoRepository;

        public CadastroBusiness(IClienteRepository clienteRepository, IEnderecoRepository enderecoRepository)
        {
            _clienteRepository = clienteRepository;
            _enderecoRepository = enderecoRepository;
        }
        
        public async Task<string> CadastrarCliente(CadastroClienteViewModel cadastroCliente)
        {
            var id = Guid.NewGuid().ToString();

            var cliente = ClienteAdapter.ToModel(id, cadastroCliente);

            await _clienteRepository.Inserir(cliente);

            var enderecos = cadastroCliente.Enderecos.Select(endereco =>
            {
                var enderecoId = Guid.NewGuid().ToString();

                return EnderecoAdapter.ToModel(enderecoId, cliente.Id, endereco);
            });

            await _enderecoRepository.Inserir(enderecos);

            await _clienteRepository.Commitar();

            return id;
        }

        public async Task<ClienteEnderecoViewModel?> ObterCliente(string cpf)
        {
            var cliente = await _clienteRepository.ObterPorCpf(cpf);

            if (cliente == null)
            {
                return null;
            }

            return ClienteAdapter.ToJoinEnderecoViewModel(cliente);
        }

        public async Task<IEnumerable<ClienteViewModel>> ObterClientes()
        {
            var clientes = await _clienteRepository.Obter();

            return clientes.Select(cliente => ClienteAdapter.ToViewModel(cliente));
        }
    }
}
