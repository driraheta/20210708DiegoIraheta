using System;

namespace AFPAPI.Entities
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; init; }
        public string Modelo { get; init; }
        public int Anio { get; init; }
        public string Uso { get; init; }
    }
}