using Admin.DTO;

namespace Admin.Interfaces
{
    public interface IArlService
    {
        Task Add(ArlCreateDTO dto);
        Task Delete(ArlDTO dto);
        Task<List<ArlDTO>> GetAll();
        Task UpdateAsset(ArlDTO dto);
    }
}