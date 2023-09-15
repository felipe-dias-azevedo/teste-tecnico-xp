using FelipeAzevedo.TesteXP.Models;
using FelipeAzevedo.TesteXP.Resources.Context;

namespace FelipeAzevedo.TesteXP.Repositories.Endereco
{
    public class EnderecoRepository : GenericRepository<EnderecoModel>, IEnderecoRepository
    {
        public EnderecoRepository(XpContext ctx) : base(ctx)
        {
        }
    }
}
