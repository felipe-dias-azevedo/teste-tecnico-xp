using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.Models;
using FelipeAzevedo.TesteXP.Resources.Context;
using Microsoft.EntityFrameworkCore;

namespace FelipeAzevedo.TesteXP.Repositories.Cliente
{
    public class ClienteRepository : GenericRepository<ClienteModel>, IClienteRepository
    {
        public ClienteRepository(XpContext ctx) : base(ctx)
        {
        }
        
        public async Task<ClienteModel?> ObterPorCpf(string cpf)
        {
            return await _ctx.Clientes
                .Include(x => x.Enderecos)
                .FirstOrDefaultAsync(c => c.Cpf == cpf);
        }
    }
}