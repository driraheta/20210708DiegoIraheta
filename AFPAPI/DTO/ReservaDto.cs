using System.ComponentModel.DataAnnotations;
using System;

namespace AFPAPI.DTO
{
    public record ReservaDto
    {
        [Required]
        public int Vehiculo { get; set; }
        [Required]
        public int Cliente { get; set; }
        public DateTimeOffset Desde { get; init; }
        public DateTimeOffset Hasta { get; init; }
        [Required]
        public bool Vendido { get; init; }
    } 
}