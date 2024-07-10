using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  CecoController: ControllerBase
    {
        private readonly ICecoService _cecoService;

        public CecoController(ICecoService cecoService)
        {
            _cecoService = cecoService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var dto = await _cecoService.GetAll();
            return Ok(new { Result = dto });
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Add(CecoCreateDTO dto)
        {
            await _cecoService.Add(dto);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> Put(CecoDTO dto)
        {
            await _cecoService.Update(dto);
            return Ok();
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(CecoDTO dto)
        {
            await _cecoService.Delete(dto);
            return Ok();
        }
    }
}