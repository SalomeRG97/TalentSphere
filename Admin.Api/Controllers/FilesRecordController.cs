using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;
using Admin.Interfaces.Utilities;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesRecordController : ControllerBase
    {
        private readonly IFilesRecordService _filesRecordService;

        public FilesRecordController(IFilesRecordService filesRecordService)
        {
            _filesRecordService = filesRecordService;
        }
        //[HttpGet("GetAll")]
        //public async Task<IActionResult> Get()
        //{
        //    var dto = await _filesRecordService.GetAll();
        //    return Ok(new { Result = dto });
        //}
        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(string IdentificadorEmpleado, int ContentType, IFormFile file)
        {
            await _filesRecordService.UploadFileEmpleado(IdentificadorEmpleado, ContentType, file);
            return Ok();
        }
        //[HttpPut("Update")]
        //public async Task<IActionResult> Put(ArlDTO dto)
        //{
        //    await _filesRecordService.Update(dto);
        //    return Ok();
        //}
        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(ArlDTO dto)
        //{
        //    await _filesRecordService.Delete(dto);
        //    return Ok();
        //}
    }
}