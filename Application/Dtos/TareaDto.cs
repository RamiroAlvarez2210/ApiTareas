
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class TareaDto
    {
        [Required]
        public string Titulo { get; set; } = null!;
        public string? NombreUsuario { get; set; }
        public int Estado { get; set; }
        public int Prioridad { get; set; }
        //public string? Descripcion {get;set;}
    }
}