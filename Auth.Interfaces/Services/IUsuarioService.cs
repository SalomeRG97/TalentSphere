using Auth.DTO;
using DTO.ServiceCall;

namespace Auth.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task Add(RequestActivarEmpleado dto);
        Task<List<UsuarioDTO>> GetAll();

    }
}