using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IArlService
    {
        Task Add(ArlCreateDTO dto);
        Task Delete(ArlDTO dto);
        Task<List<ArlDTO>> GetAll();
        Task Update(ArlDTO dto);
    }
}