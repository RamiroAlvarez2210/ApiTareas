using Domain.Entities;

namespace Domain.Entities
{
    public class Equipo : BaseEntity
    {
        public string Serial {get;set;} = null!;
        public string Marca {get;set;} = null!;
        public string Modelo {get;set;} = null!;
    }   
}