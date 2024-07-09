using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IServicioService
    {
        Task Add(ServicioCreateDTO dto);
        Task Delete(ServicioDTO dto);
        Task<List<ServicioDTO>> GetAll();
        Task Update(ServicioDTO dto);
    }
}