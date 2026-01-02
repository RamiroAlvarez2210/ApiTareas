using Application.Dtos;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Mappers
{
    public class AsignacionMapper : IMapper<Asignacion, AsignacionDto>
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;
        private readonly IGenericRepository<Equipo> _equipoRepository;
        public AsignacionMapper(IUsuarioRepository<Usuario> usuarioRepository, IEquipoRepository<Equipo> equipoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _equipoRepository = equipoRepository;
        }
        public Asignacion ToEntity(AsignacionDto dto)
        {
            return new Asignacion
            {
                Fecha = dto.Fecha,
                IdUsuario = _usuarioRepository.GetByGuid(dto.UsuarioId).Id,
                IdEquipo = _equipoRepository.GetByGuid(dto.EquipoId).Id
            };
        }
        public AsignacionDto ToDto(Asignacion entity)
        {
            return new AsignacionDto
            {
                Fecha = entity.Fecha,
                UsuarioId = _usuarioRepository.GetById(entity.IdUsuario).PublicId,
                EquipoId = _equipoRepository.GetById(entity.IdEquipo).PublicId,
                PublicId = entity.PublicId
            };
        }   
    }
}