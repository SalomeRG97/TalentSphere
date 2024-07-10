using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioService _servicioService;

        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _servicioService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(ServicioCreateDTO dto)
        {
            await _servicioService.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(ServicioDTO dto)
        {
            await _servicioService.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(ServicioDTO dto)
        {
            await _servicioService.Delete(dto);
            return Ok();
        }
    }
}