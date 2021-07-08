
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
    public class VehiculoRepository : IVehiculo
    {
        private readonly IConfiguration _config;
        public VehiculoRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection {
            get {
                return new SqlConnection(_config.GetConnectionString("afpsql"));
            }
        }

        public async Task AddVehiculo(Vehiculo vehiculo)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "sp_vehiculo";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@accion", "C");
                    param.Add("@marca", vehiculo.Marca);
                    param.Add("@modelo", vehiculo.Modelo);
                    param.Add("@anio", vehiculo.Anio);
                    param.Add("@uso", vehiculo.Uso);             
                    await con.QueryAsync(sQuery, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Vehiculo>> GetVehiculos()
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "sp_vehiculo";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@accion", "A");           
                    var response = await con.QueryAsync<Vehiculo>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return response.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}