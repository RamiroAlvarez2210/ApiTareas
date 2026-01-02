namespace Domain.Repositories
{
    public interface IGenericRepository<TEntity>
    {
        Guid Add(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByGuid(Guid guid);
        //TEntity GetByGuid(Guid guid);
        bool Update(TEntity entity);
        bool Delete(Guid id); //void Delete(TEntity entity);
        Task SaveChanges();
    }
}   