using FelipeAzevedo.TesteXP.ViewModels.Cadastro;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace FelipeAzevedo.TesteXP.UnitTests.Cadastro.Cliente
{
    public class CadastroClienteViewModelValidationTest : CadastroFixture
    {
        [Theory]
        [InlineData("a@a.co", true)]
        [InlineData("foo.bar@gmail.com", true)]
        [InlineData("foo.bar@gmail.com.br", true)]
        [InlineData("foo.bar@gmail.", false)]
        [InlineData("foo.bar@gmailcom", false)]
        [InlineData("foo.bargmail.com", false)]
        [InlineData("johndoe@gmail.com_", false)]
        [InlineData("johndoe", false)]
        [InlineData("johndoe@@gmail.com", false)]
        [InlineData("johndoe@gmail.com.", false)]
        [InlineData("@gmail.com", false)]
        public void ValidarEmail(string email, bool valid)
        {
            var payload = new CadastroClienteViewModel
            {
                Cpf = CpfGenerico,
                Nome = NomeGenerico,
                Telefone = TelefoneGenerico,
                Email = email,
                Enderecos = new List<CadastroEnderecoViewModel>
                {
                    new CadastroEnderecoViewModel
                    {
                        Cep = CepGenerico
                    }
                }
            };

            var context = new ValidationContext(payload, null, null);
            var results = new List<ValidationResult>();
            var modelState = Validator.TryValidateObject(payload, context, results, true);

            Assert.Equal(valid, modelState);
        }

        [Theory]
        [InlineData("11999999999", true)]
        [InlineData("21999999999", true)]
        [InlineData("1199999999", false)]
        [InlineData("219999999999", false)]
        [InlineData("119999999", false)]
        [InlineData("219999999", false)]
        [InlineData("11999999", false)]
        [InlineData("21999999", false)]
        public void ValidateTelefone(string telefone, bool valid)
        {
            var payload = new CadastroClienteViewModel
            {
                Cpf = CpfGenerico,
                Nome = NomeGenerico,
                Telefone = telefone,
                Email = EmailGenerico,
                Enderecos = new List<CadastroEnderecoViewModel>
                {
                    new CadastroEnderecoViewModel
                    {
                        Cep = CepGenerico
                    }
                }
            };

            var context = new ValidationContext(payload, null, null);
            var results = new List<ValidationResult>();
            var modelState = Validator.TryValidateObject(payload, context, results, true);

            Assert.Equal(valid, modelState);
        }
    }
}
