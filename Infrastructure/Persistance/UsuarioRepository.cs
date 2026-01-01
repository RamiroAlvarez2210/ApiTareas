using Domain.Entities;
using Domain.Repositories;


namespace Infraestructure.Persistance
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository<Usuario>
    {
        private readonly TareasDbContext _context;
        public UsuarioRepository(TareasDbContext context) : base(context)
        {
            _context = context;
        }
        public int GetByNombreUsuario(string nombreUsuario)
        {
            return _context.Usuarios.Where(u => u.Nombre == nombreUsuario).Select(u => u.Id).FirstOrDefault();
        }
    }
}