using System.Collections.Generic;
using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.Resources.Context;
using Microsoft.EntityFrameworkCore;

namespace FelipeAzevedo.TesteXP.Repositories
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {
        protected readonly XpContext _ctx;
        
        public GenericRepository(XpContext ctx)
        {
            _ctx = ctx;
        }
        
        public async Task<IEnumerable<T>> Obter()
        {
            return await _ctx.Set<T>()
                .ToListAsync();
        }

        public async Task Inserir(T model)
        {
            await _ctx.Set<T>().AddAsync(model);
            await _ctx.SaveChangesAsync();
        }
    }
}