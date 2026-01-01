using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public class EquipoMapper : IMapper<Equipo, EquipoDto>
    {
        public Equipo ToEntity(EquipoDto dto)
        {
            return new Equipo
            {
                Serial = dto.Serial,
                Marca = dto.Marca,
                Modelo = dto.Modelo
            };
        }
        public EquipoDto ToDto(Equipo entity)
        {
            return new EquipoDto
            {
                Serial = entity.Serial,
                Marca = entity.Marca,
                Modelo = entity.Modelo
            };
        }   
    }
}