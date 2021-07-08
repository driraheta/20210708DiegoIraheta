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
    [Route("vehiculos")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculo repository;

        public VehiculosController(IVehiculo repository)
        {
            this.repository = repository;
        }

        //GET /vehiculos
        [HttpGet]
        public async Task<List<Vehiculo>> GetVehiculos()
        {
            var vehiculos = await repository.GetVehiculos();
            return vehiculos;
        }


        //POST /vehiculos
        [HttpPost]
        public async Task<ActionResult> AddVehiculo(VehiculoDto vehiculo)
        {
            Vehiculo item = new()
            {
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                Uso = vehiculo.Uso
            };

            await repository.AddVehiculo(item);
             return RedirectToAction("GetVehiculos");
        }
    }
}