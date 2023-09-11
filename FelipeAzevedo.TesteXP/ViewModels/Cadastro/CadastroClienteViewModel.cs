﻿using System.Collections.Generic;

namespace FelipeAzevedo.TesteXP.ViewModels.Cadastro
{
    public class CadastroClienteViewModel
    {
        public string Cpf { get; set; }
        
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public List<CadastroEnderecoViewModel> Enderecos { get; set; }
    }
}
