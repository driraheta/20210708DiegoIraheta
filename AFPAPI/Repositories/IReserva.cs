using AFPAPI.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AFPAPI.Repositories
{
    public interface IReserva
    {
        Task AddReserva(Reserva reserva);
        Task<List<Reserva>> GetReservas();
    }
}