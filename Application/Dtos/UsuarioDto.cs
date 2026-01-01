
using System.ComponentModel.DataAnnotations;


namespace Application.Dtos
{
    public class UsuarioDto
    {
        [Required]
        public string Nombre {get;set;} = null!;
        public string? Correo {get;set;}
    
    }
}