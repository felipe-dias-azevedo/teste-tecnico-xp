using System.Collections.Generic;
using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.ViewModels.Cadastro;

namespace FelipeAzevedo.TesteXP.Business
{
    public interface ICadastroBusiness
    {
        public Task<ClienteEnderecoViewModel?> ObterCliente(string cpf);

        public Task<IEnumerable<ClienteViewModel>> ObterClientes();

        public Task<string> CadastrarCliente(CadastroClienteViewModel cadastroCliente);
    }
}
