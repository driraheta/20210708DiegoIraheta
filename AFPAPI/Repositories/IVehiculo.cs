using AFPAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFPAPI.Repositories
{
    public interface IVehiculo
    {
        Task<List<Vehiculo>> GetVehiculos();
        Task AddVehiculo(Vehiculo vehiculo);
    }
}