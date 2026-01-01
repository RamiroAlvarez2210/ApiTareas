using Domain.Entities;
using Domain.Repositories;


namespace Infraestructure.Persistance
{
    public class EquipoRepository : GenericRepository<Equipo>, IEquipoRepository<Equipo>
    {
        private readonly TareasDbContext _context;
        public EquipoRepository(TareasDbContext context) : base(context)
        {
            _context = context;
        }
        public int GetBySerial(string serialEquipo)
        {
            return _context.Equipos.Where(u => u.Serial == serialEquipo).Select(u => u.Id).FirstOrDefault();
        }
    }
}