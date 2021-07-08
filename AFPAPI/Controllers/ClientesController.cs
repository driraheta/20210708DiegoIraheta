using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AFPAPI.Repositories;
using AFPAPI.Entities;
using AFPAPI.DTO;

namespace AFPAPI.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly ICliente repository;

        public ClientesController(ICliente repository)
        {
            this.repository = repository;
        }

        //GET /clientes
        [HttpGet]
        public async Task<List<Cliente>> GetClientes()
        {
            var clientes = await repository.GetClientes();
            return clientes;
        }


        //GET /clientes/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(string id)
        {
            var clientes = await repository.GetClienteById(id);
            return clientes;
        }

        //POST /clientes
        [HttpPost]
        public async Task<ActionResult> AddCliente(ClienteDTO cliente)
        {
            Cliente item = new()
            {
                Nombres = cliente.Nombre,
                Apellidos = cliente.Apellido,
                Email = cliente.Email,
                DUI = cliente.DUI,
                Creado = DateTimeOffset.UtcNow
            };

            await repository.AddCliente(item);
            return Ok();
        }

        

    }
}