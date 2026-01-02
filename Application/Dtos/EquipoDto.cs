using System.ComponentModel.DataAnnotations;
namespace Application.Dtos
{
    public class EquipoDto : BaseDto
    {
        [Required]
        public string Serial { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
    }
}