using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Domain.Entities;

namespace Infraestructure.Persistance
{
    public class TareasDbContext : DbContext
    {
        public TareasDbContext(DbContextOptions<TareasDbContext> options) : base(options) { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Asignacion> Asignaciones { get; set; }
    }
}