using FelipeAzevedo.TesteXP.Business;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.ViewModels.Cadastro;
using System;

namespace FelipeAzevedo.TesteXP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroBusiness _cadastroBusiness;

        public CadastroController(ICadastroBusiness cadastroBusiness)
        {
            _cadastroBusiness = cadastroBusiness;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> ObterClientes()
        {
            var clientes = await _cadastroBusiness.ObterClientes();

            if (!clientes.Any())
            {
                return NoContent();
            }

            return Ok(clientes);
        }

        [HttpGet("clientes/{cpf}")]
        public async Task<IActionResult> ObterCliente([FromRoute] string cpf)
        {
            var cliente = await _cadastroBusiness.ObterCliente(cpf);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost("clientes")]
        public async Task<IActionResult> CadastrarCliente([FromBody] CadastroClienteViewModel cadastroCliente)
        {
            try
            {
                await _cadastroBusiness.CadastrarCliente(cadastroCliente);

                return StatusCode((int)HttpStatusCode.Created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
