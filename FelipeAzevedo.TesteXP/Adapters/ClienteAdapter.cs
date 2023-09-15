using FelipeAzevedo.TesteXP.Models;
using FelipeAzevedo.TesteXP.ViewModels.Cadastro;
using System.Linq;

namespace FelipeAzevedo.TesteXP.Adapters
{
    public static class ClienteAdapter
    {
        public static ClienteModel ToModel(string id, CadastroClienteViewModel cadastroCliente)
        {
            return new ClienteModel
            {
                Id = id,
                Cpf = cadastroCliente.Cpf,
                Email = cadastroCliente.Email,
                Nome = cadastroCliente.Nome,
                Telefone = cadastroCliente.Telefone
            };
        }

        public static ClienteViewModel ToViewModel(ClienteModel cliente)
        {
            return new ClienteViewModel
            {
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone
            };
        }

        public static ClienteEnderecoViewModel ToJoinEnderecoViewModel(ClienteModel cliente)
        {
            return new ClienteEnderecoViewModel
            {
                Cpf = cliente.Cpf,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Enderecos = cliente.Enderecos.Select(endereco => EnderecoAdapter.ToViewModel(endereco)).ToList()
            };
        }
    }
}
