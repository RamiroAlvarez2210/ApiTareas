namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
    }
}