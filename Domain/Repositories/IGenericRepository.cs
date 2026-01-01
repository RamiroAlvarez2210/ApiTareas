namespace Domain.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        bool Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        bool Update(TEntity entity);
        bool Delete(int id); //void Delete(TEntity entity);
        Task SaveChanges();
    }
}   