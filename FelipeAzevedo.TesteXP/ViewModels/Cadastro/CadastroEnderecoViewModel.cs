using System.ComponentModel.DataAnnotations;

namespace FelipeAzevedo.TesteXP.ViewModels.Cadastro
{
    public class CadastroEnderecoViewModel
    {
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string Cep { get; set; }
    }
}