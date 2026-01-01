using System.ComponentModel.DataAnnotations.Schema;
namespace Domain.Entities
{
    public class Asignacion : BaseEntity
    {
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; } = null!;
        public int IdEquipo { get; set; }
        [ForeignKey("IdEquipo")]
        public Usuario Equipo { get; set; } = null!;
        public DateTime Fecha { get; set; }
    
    }
}