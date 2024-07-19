using Admin.Interfaces.Service.Master;
using Admin.DTO;
using Microsoft.AspNetCore.Mvc;
using Interfaces.Utilities;
using Microsoft.JSInterop;
using Utilidades;
using Exceptions;

namespace Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesRecordController : ControllerBase
    {
        private readonly IFilesRecordService _filesRecordService;
        private readonly IManejadorArchivosLocal _manejadorArchivosLocal;

        public FilesRecordController(IFilesRecordService filesRecordService, IManejadorArchivosLocal manejadorArchivosLocal)
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
        public async Task<IActionResult> Upload(string IdentificadorEmpleado, int ContentType, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new BadRequestException("Error: El archivo es incorrecto.");
            }
            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var content = ms.ToArray();

            var dto = await _manejadorArchivosLocal.GuardarArchivo(file.FileName, "documentos", IdentificadorEmpleado, ContentType);
            await _filesRecordService.UploadFileEmpleado(dto, content);
            return Ok("El proceso salio bien");
        }

    }
}