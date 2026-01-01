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
        public override bool AddAsync(AsignacionDto dto)
        {
            int usuario = _usuarioRepository.GetByNombreUsuario(dto.NombreUsuario)
                .BusquedaEntidad($"El usuario '{dto.NombreUsuario}' no existe.");

            int equipo = _equipoRepository.GetBySerial(dto.NombreEquipo)
                .BusquedaEntidad($"El equipo con serial '{dto.NombreEquipo}' no existe.");

            Asignacion nuevaAsignacion = new Asignacion
            {
                Fecha = dto.Fecha,
                IdUsuario = usuario,
                IdEquipo = equipo
            };
            return _asignacionRepository.Add(nuevaAsignacion);
        }
        public override IEnumerable<AsignacionDto> GetAllAsync()
        {
            IEnumerable<Asignacion> asignaciones = _asignacionRepository.GetAll();
            return asignaciones.Select(t => new AsignacionDto
            {
                Fecha = t.Fecha,
                NombreEquipo = _equipoRepository.GetById(t.IdEquipo).Marca,
                NombreUsuario =_usuarioRepository.GetById(t.IdUsuario).Nombre
            });
        }
    }
}