using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FelipeAzevedo.TesteXP.ViewModels.Cadastro
{
    public class CadastroClienteViewModel
    {
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string Cpf { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nome { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^\(?(?:[14689][1-9]|2[12478]|3[1234578]|5[1345]|7[134579])\)? ?(?:[2-8]|9[0-9])[0-9]{3}\-?[0-9]{4}$")]
        public string Telefone { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        [Required]
        [MinLength(1)]
        public List<CadastroEnderecoViewModel> Enderecos { get; set; }
    }
}
