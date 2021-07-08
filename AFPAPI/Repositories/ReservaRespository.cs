
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using AFPAPI.Entities;

namespace AFPAPI.Repositories
{
    public class ReservaRepository : IReserva
    {
        private readonly IConfiguration _config;
        public ReservaRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection {
            get {
                return new SqlConnection(_config.GetConnectionString("afpsql"));
            }
        }

        public Task AddReserva(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public Task<List<Reserva>> GetReservas()
        {
            throw new NotImplementedException();
        }
    }
}