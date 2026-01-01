using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructure.Persistance
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TareasDbContext _context;
        public GenericRepository(TareasDbContext context)
        {
            _context = context;
        }
        public bool Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            return _context.SaveChanges() > 0;
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id)!;
        }
        public bool Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return _context.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            var entity = GetById(id);
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