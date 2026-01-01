using Application.Mappers;
using Domain.Repositories;

namespace Application.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TDto> 
        //where TEntity : BaseEntity // <-- Restricción clave
    {
        private readonly IGenericRepository<TEntity> _genericRepository;
        private readonly IMapper<TEntity, TDto> _mapper;

        public GenericService(IGenericRepository<TEntity> genericRepository, IMapper<TEntity, TDto> mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public virtual bool AddAsync(TDto dto)
        {
            return _genericRepository.Add(_mapper.ToEntity(dto));
        }

        public virtual IEnumerable<TDto> GetAllAsync()
        {
            return _genericRepository.GetAll().Select(_mapper.ToDto);
        }

        // Ahora puedes recibir un int 'id' directamente
        public TDto GetbyId(int id)
        {
            var entity = _genericRepository.GetById(id);
            return _mapper.ToDto(entity);
        }

        public bool UpdateAsync(TDto dto)
        {
            var entity = _mapper.ToEntity(dto);
            // Gracias a la restricción, el compilador sabe que entity tiene .Id
            return _genericRepository.Update(entity);
        }

        public bool DeleteAsync(int id)
        {
            return _genericRepository.Delete(id);
        }
    }
}