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
    }
}
