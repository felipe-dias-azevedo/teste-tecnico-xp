using FelipeAzevedo.TesteXP.Business;
using FelipeAzevedo.TesteXP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

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

        [HttpGet]
        public async Task<IActionResult> ObterClientes()
        {
            var clientes = await _cadastroBusiness.ObterClientes();

            if (!clientes.Any())
            {
                return NoContent();
            }

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterCliente([FromRoute] string id)
        {
            var cliente = await _cadastroBusiness.ObterCliente(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] CadastroClienteViewModel cadastroCliente)
        {
            await _cadastroBusiness.CadastrarCliente(cadastroCliente);

            return StatusCode((int) HttpStatusCode.Created);
        }
    }
}
