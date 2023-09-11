using System.Collections.Generic;
using System.Threading.Tasks;
using FelipeAzevedo.TesteXP.Models;

namespace FelipeAzevedo.TesteXP.Repositories.Cliente
{
    public interface IClienteRepository : IGenericRepository<ClienteModel> 
    {
        public Task<ClienteModel?> ObterPorCpf(string cpf);
    }
}