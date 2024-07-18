using Auth.DTO;
using Admin.DTO.ServiceCall;

namespace Auth.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task Add(RequestActivarEmpleado dto);
        Task<List<UsuarioDTO>> GetAll();

    }
}