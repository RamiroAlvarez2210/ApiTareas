using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class AsignacionDto
    {
        [Required]
        public string NombreUsuario { get; set; } = null!;
        [Required]
        public string NombreEquipo { get; set; } = null!;
        public DateTime Fecha { get; set; } = DateTime.Now;
    
    }
}