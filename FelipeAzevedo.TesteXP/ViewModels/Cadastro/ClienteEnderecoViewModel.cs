using System.Collections.Generic;

namespace FelipeAzevedo.TesteXP.ViewModels.Cadastro
{
    public class ClienteEnderecoViewModel
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public IEnumerable<EnderecoViewModel> Enderecos { get; set; }
    }
}