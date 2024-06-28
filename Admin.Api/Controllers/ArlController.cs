using Admin.Interfaces;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArlController : ControllerBase
    {
        private readonly IArlService _arlService;

        public ArlController(IArlService arlService)
        {
            _arlService = arlService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _arlService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(ArlCreateDTO dto)
        {
            await _arlService.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(ArlDTO dto)
        {
            await _arlService.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(ArlDTO dto)
        {
            await _arlService.Delete(dto);
            return Ok();
        }
    }
}