using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoContratoController : ControllerBase
    {
        private readonly ITipoContratoService _tipoContratoservice;

        public TipoContratoController(ITipoContratoService tipoContratoservice)
        {
            _tipoContratoservice = tipoContratoservice;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _tipoContratoservice.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(TipoContratoCreateDTO dto)
        {
            await _tipoContratoservice.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(TipoContratoDTO dto)
        {
            await _tipoContratoservice.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(TipoContratoDTO dto)
        {
            await _tipoContratoservice.Delete(dto);
            return Ok();
        }
    }
}