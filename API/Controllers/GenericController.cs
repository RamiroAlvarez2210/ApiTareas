
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TDto> : ControllerBase
    {
        
        private readonly IGenericService<TDto> _genericService;
        public GenericController(IGenericService<TDto> genericService)
        {
            _genericService = genericService;
        }
        [HttpGet]
        //public async Task<IEnumerable<TDto>> GetAll()
        public IActionResult GetAll()
        {
            var datos = _genericService.GetAllAsync();
            return Ok(datos);
            //return await _genericService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> Add(TDto dto)
        {
            if ( _genericService.AddAsync(dto))
            {
                return Ok("Entidad agregada correctamente");
            }
            return BadRequest("Error al agregar la entidad");
        }
    }
}