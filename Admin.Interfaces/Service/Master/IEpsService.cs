using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IEpsService
    {
        Task Add(EpsCreateDTO dto);
        Task Delete(EpsDTO dto);
        Task<List<EpsDTO>> GetAll();
        Task Update(EpsDTO dto);
    }
}