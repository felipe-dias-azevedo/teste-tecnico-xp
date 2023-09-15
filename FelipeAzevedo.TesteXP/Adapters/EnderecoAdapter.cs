using FelipeAzevedo.TesteXP.Models;
using FelipeAzevedo.TesteXP.ViewModels.Cadastro;
using System;

namespace FelipeAzevedo.TesteXP.Adapters
{
    public static class EnderecoAdapter
    {
        public static EnderecoModel ToModel(string enderecoId, string clienteId, CadastroEnderecoViewModel endereco)
        {
            return new EnderecoModel
            {
                Id = enderecoId,
                IdCliente = clienteId,
                Cep = endereco.Cep
            };
        }

        public static EnderecoViewModel ToViewModel(EnderecoModel endereco)
        {
            return new EnderecoViewModel
            {
                Cep = endereco.Cep,
            };
        }
    }
}
