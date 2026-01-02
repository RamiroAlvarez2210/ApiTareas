using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class AsignacionDto : BaseDto
    {
        [Required]
        //public string NombreUsuario { get; set; } = null!;
        public Guid UsuarioId { get; set; }
        [Required]
        //public string NombreEquipo { get; set; } = null!;
        public Guid EquipoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}