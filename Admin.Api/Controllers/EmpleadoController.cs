using Admin.DTO;
using Admin.DTO.Maestros;
using Admin.Interfaces.Service.Master;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoservice;

        public EmpleadoController(IEmpleadoService empleadoservice)
        {
            _empleadoservice = empleadoservice;
        }

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> Get()
        //{
        //    var dto = await _empleadoservice.GetAll();
        //    return Ok(new { Result = dto });
        //}
        [HttpPost("Create")]
        public async Task<IActionResult> Add(RequestCreateEmpleado dto)
        {
            await _empleadoservice.Add(dto);
            return Ok();
        }
        //[HttpPut("Update")]
        //public async Task<IActionResult> Put(ArlDTO dto)
        //{
        //    await _empleadoservice.Update(dto);
        //    return Ok();
        //}
        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(ArlDTO dto)
        //{
        //    await _empleadoservice.Delete(dto);
        //    return Ok();
        //}
    }
}
