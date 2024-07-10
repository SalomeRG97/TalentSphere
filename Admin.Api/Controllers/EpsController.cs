using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpsController : ControllerBase
    {
        private readonly IEpsService _epsService;

        public EpsController(IEpsService epsService)
        {
            _epsService = epsService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _epsService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(EpsCreateDTO dto)
        {
            await _epsService.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(EpsDTO dto)
        {
            await _epsService.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(EpsDTO dto)
        {
            await _epsService.Delete(dto);
            return Ok();
        }
    }
}