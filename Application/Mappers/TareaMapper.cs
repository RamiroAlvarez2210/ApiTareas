using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers
{
    public class TareaMapper : IMapper<Tarea, TareaDto>
    {
        public Tarea ToEntity(TareaDto dto)
        {
            return new Tarea
            {
                Titulo = dto.Titulo
            };
        }
        public TareaDto ToDto(Tarea entity)
        {
            return new TareaDto
            {
                PublicId = entity.PublicId,
            };
        }   
    }
}