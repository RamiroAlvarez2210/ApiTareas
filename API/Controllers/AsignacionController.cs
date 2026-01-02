using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AsignacionController : GenericController<AsignacionDto>
    {
        private readonly AsignacionService _asignacionService;
        public AsignacionController(IGenericService<AsignacionDto> genericService,
            AsignacionService asignacionService)
            : base(genericService)
        {
            _asignacionService = asignacionService;
        }
        [HttpPost("AltaUsuarioEquipo")]
        public async Task<IActionResult> AltaUsuarioEquipo(AltaUsuarioEquipoDto dto)
        {
            var result = await Task.Run(() => _asignacionService.AltaUsuarioEquipoAsync(dto));
            if (result != Guid.Empty)
            {
                return Ok($"Entidad agregada correctamente. PublicId: {result}");
            }
            return BadRequest("Error al agregar la entidad");
        }
    }
}