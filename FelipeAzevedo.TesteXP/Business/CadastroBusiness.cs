using FelipeAzevedo.TesteXP.Models;
using FelipeAzevedo.TesteXP.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FelipeAzevedo.TesteXP.Business
{
    public class CadastroBusiness : ICadastroBusiness
    {
        public Task<string> CadastrarCliente(CadastroClienteViewModel cadastroCliente)
        {
            var id = Guid.NewGuid().ToString();

            var cliente = new ClienteModel
            {
                Id = id,
            };

            throw new System.NotImplementedException();
        }

        public Task<ClienteViewModel?> ObterCliente(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ClienteViewModel>> ObterClientes()
        {
            throw new System.NotImplementedException();
        }
    }
}
