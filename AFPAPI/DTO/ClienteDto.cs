using System.ComponentModel.DataAnnotations;

namespace AFPAPI.DTO
{
    public record ClienteDTO
    {
        [Required]
        public string Nombre { get; init; }

        [Required]
        public string Apellido { get; init; }

        [Required]
        [EmailAddress]
        public string Email { get; init; }

        [Required]
        public string DUI { get; init; }
    }
}