using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public class UsuarioMapper : IMapper<Usuario, UsuarioDto>
    {
        public Usuario ToEntity(UsuarioDto dto)
        {
            return new Usuario
            {
                Nombre = dto.Nombre,
                Correo = dto.Correo ?? ""
            };
        }
        public UsuarioDto ToDto(Usuario entity)
        {
            return new UsuarioDto
            {
                Nombre = entity.Nombre,
                Correo = entity.Correo
            };
        }   
    }
}