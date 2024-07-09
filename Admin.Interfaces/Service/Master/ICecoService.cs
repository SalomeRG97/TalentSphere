using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface ICecoService
    {
        Task Add(CecoCreateDTO dto);
        Task Delete(CecoDTO dto);
        Task<List<CecoDTO>> GetAll();
        Task Update(CecoDTO dto);
    }
}