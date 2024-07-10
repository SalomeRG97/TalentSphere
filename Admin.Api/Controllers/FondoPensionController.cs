using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FondoPensionController : ControllerBase
    {
        private readonly IFondoPensionService _fondoPensionService;

        public FondoPensionController(IFondoPensionService fondoPensionService)
        {
            _fondoPensionService = fondoPensionService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _fondoPensionService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(FondoPensionCreateDTO dto)
        {
            await _fondoPensionService.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(FondoPensionDTO dto)
        {
            await _fondoPensionService.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(FondoPensionDTO dto)
        {
            await _fondoPensionService.Delete(dto);
            return Ok();
        }
    }
}