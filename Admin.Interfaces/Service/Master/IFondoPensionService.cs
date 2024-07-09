using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IFondoPensionService
    {
        Task Add(FondoPensionCreateDTO dto);
        Task Delete(FondoPensionDTO dto);
        Task<List<FondoPensionDTO>> GetAll();
        Task Update(FondoPensionDTO dto);
    }
}