
using System.ComponentModel.DataAnnotations;


namespace Application.Dtos
{
    public class UsuarioDto : BaseDto
    {
        [Required]
        public string Nombre {get;set;} = null!;
        public string? Correo {get;set;}
    }
}