using Admin.DTO;
using Microsoft.AspNetCore.Http;

namespace Admin.Interfaces.Service.Master
{
    public interface IFilesRecordService
    {
        Task<List<FilesRecordDTO>> GetAll();
        Task UploadFileEmpleado(FilesRecordDTO dto, byte[] file);
    }
}