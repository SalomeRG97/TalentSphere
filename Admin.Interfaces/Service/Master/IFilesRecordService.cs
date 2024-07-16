using Admin.DTO;
using Microsoft.AspNetCore.Http;

namespace Admin.Interfaces.Service.Master
{
    public interface IFilesRecordService
    {
        Task UploadFileEmpleado(string IdentificadorEmpleado, int ContentType, IFormFile file);
        Task Delete(FilesRecordDTO dto);
        Task<List<FilesRecordDTO>> GetAll();
        Task Update(FilesRecordDTO dto);
        Task Create(FilesRecordDTO dto);
    }
}