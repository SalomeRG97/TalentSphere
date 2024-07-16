using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IFilesRecordService
    {
        Task UploadFileEmpleado(int id, FilesRecordCreateDTO dto);
        Task Delete(FilesRecordDTO dto);
        Task<List<FilesRecordDTO>> GetAll();
        Task Update(FilesRecordDTO dto);
    }
}