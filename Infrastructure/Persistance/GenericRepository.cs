using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Persistance
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TareasDbContext _context;
        public GenericRepository(TareasDbContext context)
        {
            _context = context;
        }
        public Guid Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity.PublicId;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id)!;
        }
        public TEntity GetByGuid(Guid guid)
        {
           // return _context.Set<TEntity>().Find(guid)!;
           return _context.Set<TEntity>()
                    .AsNoTracking() // Úsalo si solo vas a leer datos, mejora el rendimiento
                    .FirstOrDefault(e => e.PublicId == guid)!;
        }
        public bool Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges() > 0;
        }
        public bool Delete(Guid id)
        {
            var entity = GetByGuid(id);
            if (entity == null) return false;
            _context.Set<TEntity>().Remove(entity);
            return _context.SaveChanges() > 0;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}