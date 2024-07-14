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
        private readonly IManejadorArchivosLocal _manejadorArchivosLocal;

        public FilesRecordController(IManejadorArchivosLocal manejadorArchivosLocal, IFilesRecordService filesRecordService)
        {
            _filesRecordService = filesRecordService;
            _manejadorArchivosLocal = manejadorArchivosLocal;
        }
        //[HttpGet("GetAll")]
        //public async Task<IActionResult> Get()
        //{
        //    var dto = await _filesRecordService.GetAll();
        //    return Ok(new { Result = dto });
        //}
        [HttpPost("Upload")]
        public async Task<IActionResult> Add(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No se ha proporcionado un archivo válido.");
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var content = ms.ToArray();

            var dto = await _manejadorArchivosLocal.GuardarArchivo(content, file.FileName, file.ContentType, "documentos");

            await _filesRecordService.Add(dto);
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