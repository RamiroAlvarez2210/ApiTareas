using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : GenericController<AsignacionDto>
    {
        public AsignacionController(IGenericService<AsignacionDto> genericService)
            : base(genericService)
        {
        }
    }
}