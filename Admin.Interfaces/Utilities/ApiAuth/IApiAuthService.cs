using DTO.ServiceCall;

namespace Admin.Interfaces.Utilities.ApiAuth
{
    public interface IApiAuthService
    {
        Task<bool> ActivarEmpleado(RequestActivarEmpleado request);
        Task<bool> DarBajaEmpleado(RequestDesactivarEmpleado request);
    }
}