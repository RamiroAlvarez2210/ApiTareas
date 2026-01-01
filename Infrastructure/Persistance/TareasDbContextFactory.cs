// DbContextFactory.cs
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infraestructure.Persistance
{
    public class TareasDbContextFactory : IDesignTimeDbContextFactory<TareasDbContext>
    {
        public TareasDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TareasDbContext>();

            // Usa la misma cadena de conexión que en appsettings.json
            optionsBuilder.UseSqlite("Data Source=GestorTareas.db");

            return new TareasDbContext(optionsBuilder.Options);
        }
    }
}