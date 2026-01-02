using Application.Dtos;
using Application.Funciones;
using Application.Mappers;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services
{
    public class AsignacionService : GenericService<Asignacion, AsignacionDto>
    {
        private readonly IGenericRepository<Asignacion> _asignacionRepository;
        private readonly IEquipoRepository<Equipo> _equipoRepository;
        private readonly IUsuarioRepository<Usuario> _usuarioRepository;

        public AsignacionService(IGenericRepository<Asignacion> asignacionRepository, IMapper<Asignacion, AsignacionDto> mapper,
            IEquipoRepository<Equipo> equipoRepository,
            IUsuarioRepository<Usuario> usuarioRepository)
            : base(asignacionRepository, mapper)
        {
            _asignacionRepository = asignacionRepository;
            _equipoRepository = equipoRepository;
            _usuarioRepository = usuarioRepository;
        }
        public override Guid AddAsync(AsignacionDto dto)
        {
            Asignacion nuevaAsignacion = new Asignacion
            {
                Fecha = dto.Fecha,
                IdUsuario = _usuarioRepository.GetByGuid(dto.UsuarioId).Id,
                IdEquipo = _equipoRepository.GetByGuid(dto.EquipoId).Id
            };
            return _asignacionRepository.Add(nuevaAsignacion);
        }
        public override IEnumerable<AsignacionDto> GetAllAsync()
        {
            IEnumerable<Asignacion> asignaciones = _asignacionRepository.GetAll();
            return asignaciones.Select(t => new AsignacionDto
            {
                Fecha = t.Fecha,
                UsuarioId = _usuarioRepository.GetById(t.IdUsuario).PublicId,
                EquipoId = _equipoRepository.GetById(t.IdEquipo).PublicId,
                PublicId = t.PublicId
            });
        }
        public override AsignacionDto GetByGuid(Guid id)
        {
            Asignacion entity = _asignacionRepository.GetByGuid(id);
            return new AsignacionDto
            {
                Fecha = entity.Fecha,
                UsuarioId = _usuarioRepository.GetById(entity.IdUsuario).PublicId,
                EquipoId = _equipoRepository.GetById(entity.IdEquipo).PublicId,
                PublicId = entity.PublicId
            };
        }
        public Guid AltaUsuarioEquipoAsync(AltaUsuarioEquipoDto dto)
        {
            Console.WriteLine("AaaAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
            Guid usuario = _usuarioRepository.Add(new Usuario
            {
                Nombre = dto.NombreUsuario,
            });
            Guid equipo = _equipoRepository.Add(new Equipo
            {
                Marca = dto.MarcaEquipo,
                Modelo = dto.ModeloEquipo,
                Serial = dto.SerialEquipo
            });
            Guid asignacion = _asignacionRepository.Add(new Asignacion
            {
                Fecha = dto.Fecha,
                IdUsuario = _usuarioRepository.GetByGuid(usuario).Id,
                IdEquipo = _equipoRepository.GetByGuid(equipo).Id
            });
            return asignacion;
        }
    }
}