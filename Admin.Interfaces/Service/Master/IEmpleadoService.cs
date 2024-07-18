using Admin.DTO;
using Admin.DTO.Maestros;

namespace Admin.Interfaces.Service.Master
{
    public interface IEmpleadoService
    {
        Task CreateEmpleado(RequestCreateEmpleado request);
        Task Delete(EmpleadoDTO dto);
        Task<List<RequestCreateEmpleado>> GetAll();
        Task UpdateEmpleado(RequestCreateEmpleado request);
    }
}