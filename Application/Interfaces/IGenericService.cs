
namespace Application.Services
{
    public interface IGenericService<TDto>
    {
        public bool AddAsync(TDto dto);
        public IEnumerable<TDto> GetAllAsync();
        public TDto GetbyId(int id);
        public bool UpdateAsync(TDto dto);
        public bool DeleteAsync(int id);
        
    }
}