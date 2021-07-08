using System;

namespace AFPAPI.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; init; }
        public string Apellidos { get; init; }
        public string Email { get; init; }
        public string DUI { get; init; }
        public DateTimeOffset Creado { get; init; }
    }
}