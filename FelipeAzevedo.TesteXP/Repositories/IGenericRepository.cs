using System.Collections.Generic;
using System.Threading.Tasks;

namespace FelipeAzevedo.TesteXP.Repositories
{
    public interface IGenericRepository <T> where T : class
    {
        public Task<IEnumerable<T>> Obter();

        public Task Inserir(T model);
    }
}