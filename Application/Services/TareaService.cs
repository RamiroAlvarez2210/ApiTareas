using Application.Dtos;
using Application.Mappers;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class TareaService : GenericService<Tarea, TareaDto>
    {
        private readonly IGenericRepository<Tarea> _tareaRepository;
        private readonly IUsuarioRepository<Usuario> _usuarioRepository;

        public TareaService(IGenericRepository<Tarea> tareaRepository, IMapper<Tarea, TareaDto> mapper,
            IUsuarioRepository<Usuario> usuarioRepository)
            : base(tareaRepository, mapper)
        {
            _tareaRepository = tareaRepository;
            _usuarioRepository = usuarioRepository;
        }
        
        public override Guid AddAsync(TareaDto dto)
        {
            //if (!existeUsuario)
            //    throw new KeyNotFoundException($"El usuario con ID {dto.IdUsuario} no existe.");
            Tarea nuevaTarea = new Tarea
            {
                Titulo = dto.Titulo,
                Estado = dto.Estado,
                Prioridad = dto.Prioridad,
            };
            if (dto.NombreUsuario != null)
            {
                nuevaTarea.IdUsuario = _usuarioRepository.GetByNombreUsuario(dto.NombreUsuario);
            }
            return _tareaRepository.Add(nuevaTarea);
        }
        public override IEnumerable<TareaDto> GetAllAsync()
        {
            IEnumerable<Tarea> tareas = _tareaRepository.GetAll();
            return tareas.Select(t => new TareaDto
            {
                Titulo = t.Titulo,
                Estado = t.Estado,
                Prioridad = t.Prioridad,
                NombreUsuario = t.IdUsuario != null ? _usuarioRepository.GetById(t.IdUsuario.Value)?.Nombre : null
            });
        }
    }
}