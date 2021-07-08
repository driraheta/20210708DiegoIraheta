using AFPAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFPAPI.Repositories
{
    public interface ICliente
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente> GetClienteById(string id);

        Task<Cliente> GetClienteByDUI(string dui);

        Task AddCliente(Cliente cliente);
    }
}