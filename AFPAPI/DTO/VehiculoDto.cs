using System.ComponentModel.DataAnnotations;

namespace AFPAPI.DTO
{
    public record VehiculoDto
    {
        [Required]
        public string Marca { get; init; }
        [Required]
        public string Modelo { get; init; }

        [Required]
        [Range(2010, double.MaxValue)]
        public int Anio { get; init; }

        [Required]
        public string Uso { get; init; }
    }
}