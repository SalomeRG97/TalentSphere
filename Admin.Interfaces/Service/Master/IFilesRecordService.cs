using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IFilesRecordService
    {
        Task Add(FilesRecordCreateDTO dto);
        Task Delete(FilesRecordDTO dto);
        Task<List<FilesRecordDTO>> GetAll();
        Task Update(FilesRecordDTO dto);
    }
}