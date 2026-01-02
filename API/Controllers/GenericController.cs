
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
            var result = await Task.Run(() => _genericService.AddAsync(dto));
            if (result != Guid.Empty)
            {
                return Ok($"Entidad agregada correctamente. PublicId: {result}");
            }
            return BadRequest("Error al agregar la entidad");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByGuid(Guid id)
        {
            var datos = await Task.Run(() => _genericService.GetByGuid(id));
            return Ok(datos);
        }
    }
}