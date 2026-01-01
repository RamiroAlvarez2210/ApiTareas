using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public class AsignacionMapper : IMapper<Asignacion, AsignacionDto>
    {
        public Asignacion ToEntity(AsignacionDto dto)
        {
            return new Asignacion
            {
            };
        }
        public AsignacionDto ToDto(Asignacion entity)
        {
            return new AsignacionDto
            {

            };
        }   
    }
}