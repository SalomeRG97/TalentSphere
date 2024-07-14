using Admin.DTO;
using Admin.DTO.Maestros;

namespace Admin.Interfaces.Service.Master
{
    public interface IEmpleadoService
    {
        Task Add(RequestCreateEmpleado request);
        Task Delete(EmpleadoDTO dto);
        Task<List<EmpleadoDTO>> GetAll();
        Task Update(EmpleadoDTO dto);
    }
}