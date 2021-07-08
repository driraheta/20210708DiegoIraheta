
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
    public class ClienteRepository : ICliente
    {
        private readonly IConfiguration _config;
        public ClienteRepository(IConfiguration config)
        {
            _config = config;
        }
        public IDbConnection connection {
            get {
                return new SqlConnection(_config.GetConnectionString("afpsql"));
            }
        }

        public async Task AddCliente(Cliente cliente)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "sp_cliente";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@accion", "C");
                    param.Add("@id", cliente.Id.ToString());
                    param.Add("@nombres", cliente.Nombres);
                    param.Add("@apellidos", cliente.Apellidos);
                    param.Add("@email", cliente.Email);
                    param.Add("@dui",cliente.DUI);                
                    await con.QueryAsync(sQuery, param, commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Cliente> GetClienteByDUI(string dui)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetClienteById(string id)
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string sQuery = "sp_cliente";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@accion", "R");
                    param.Add("@id", id);             
                    var result = await con.QuerySingleAsync<Cliente>(sQuery, param, commandType: CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Cliente>> GetClientes()
        {
            try
            {
                using (IDbConnection con = connection)
                {
                    string Query = "sp_cliente";
                    con.Open();
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@accion", "A");
                    var result = await con.QueryAsync<Cliente>(Query, param, commandType: CommandType.StoredProcedure);
                    return result.ToList();
                }
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
    }
}