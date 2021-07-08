using System;

namespace AFPAPI.Entities
{
    public class Reserva
    {
        public int Id { get; init; }
        public int Vehiculo { get; set; }
        public int Cliente { get; set; }
        public DateTimeOffset Desde { get; init; }
        public DateTimeOffset Hasta { get; init; }
        public bool Vendido { get; init; }
    }
}