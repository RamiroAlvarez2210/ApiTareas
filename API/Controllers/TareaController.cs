using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : GenericController<TareaDto>
    {
        public TareaController(IGenericService<TareaDto> genericService)
            : base(genericService)
        {
        }
    }
}