using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tarea : BaseEntity
    {
        public string Titulo { get; set; } = null!;
        public int Estado {get; set;} = 0; // en caso de no asginarlo
        public int Prioridad {get;set;}
        public int? IdUsuario{get;set;}
        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }
        //public DateTime UltimaActualizacion {get;set}
    }
}