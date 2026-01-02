
namespace Application.Services
{
    public interface IGenericService<TDto>
    {
        Guid AddAsync(TDto dto);
        IEnumerable<TDto> GetAllAsync();
        TDto GetByGuid(Guid id);
        bool UpdateAsync(TDto dto);
        bool DeleteAsync(Guid id);
        
    }
}