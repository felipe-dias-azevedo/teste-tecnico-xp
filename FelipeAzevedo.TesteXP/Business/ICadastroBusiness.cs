using FelipeAzevedo.TesteXP.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FelipeAzevedo.TesteXP.Business
{
    public interface ICadastroBusiness
    {
        public Task<ClienteViewModel?> ObterCliente(string id);

        public Task<IEnumerable<ClienteViewModel>> ObterClientes();

        public Task<string> CadastrarCliente(CadastroClienteViewModel cadastroCliente);
    }
}
