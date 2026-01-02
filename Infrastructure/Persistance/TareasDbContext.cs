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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(e => e.PublicId)
                .IsUnique(); // Esto acelera aún más la búsqueda y asegura que no se repitan
            modelBuilder.Entity<Tarea>()
                .HasIndex(e => e.PublicId)
                .IsUnique();
            modelBuilder.Entity<Equipo>()
                .HasIndex(e => e.PublicId)
                .IsUnique();
            modelBuilder.Entity<Asignacion>()
                .HasIndex(e => e.PublicId)
                .IsUnique();
        }

    }
}