namespace Application.Dtos
{
    public class AltaUsuarioEquipoDto
    {
        public string NombreUsuario { get; set; } = null!;
        public string MarcaEquipo { get; set; } = null!;
        public string ModeloEquipo { get; set; } = null!;
        public string SerialEquipo { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}