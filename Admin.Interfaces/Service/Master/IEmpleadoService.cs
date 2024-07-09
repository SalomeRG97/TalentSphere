using Admin.DTO;

namespace Admin.Interfaces.Service.Master
{
    public interface IEmpleadoService
    {
        Task Add(EmpleadoCreateDTO dto);
        Task Delete(EmpleadoDTO dto);
        Task<List<EmpleadoDTO>> GetAll();
        Task Update(EmpleadoDTO dto);
    }
}