using System;

namespace AFPAPI.Entities
{
    public class Reserva
    {
        public Guid Id { get; init; }
        public Guid Vehiculo { get; set; }
        public Guid Cliente { get; set; }
        public DateTimeOffset Desde { get; init; }
        public DateTimeOffset Hasta { get; init; }
        public bool Vendido { get; init; }
    }
}