using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EquipoController : GenericController<EquipoDto>
    {
        public EquipoController(IGenericService<EquipoDto> genericService)
            : base(genericService)
        {
        }
    }
}