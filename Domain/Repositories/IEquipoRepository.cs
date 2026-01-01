namespace Domain.Repositories
{
    public interface IEquipoRepository<Equipo> : IGenericRepository<Equipo>
    {
        public int GetBySerial(string nombreEquipo);
    }
}