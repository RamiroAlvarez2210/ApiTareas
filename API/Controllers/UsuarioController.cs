using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : GenericController<UsuarioDto>
    {
        public UsuarioController(IGenericService<UsuarioDto> genericService)
            : base(genericService)
        {
        }
    }
}