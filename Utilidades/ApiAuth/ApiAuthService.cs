using Admin.DTO.ServiceCall;
using Admin.Interfaces.Utilities.ApiAuth;

namespace Utilidades.ApiAuth
{
    public class ApiAuthService : HttpBase, IApiAuthService
    {
        public ApiAuthService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<bool> ActivarEmpleado(RequestActivarEmpleado request)
        {
            await Post<RequestActivarEmpleado, object>("User/DarAltaEmpleado", request);
            return true;
        }
        public async Task<bool> DarBajaEmpleado(RequestDesactivarEmpleado request)
        {
            await Post<RequestDesactivarEmpleado, object>("User/DarBajaEmpleado", request);
            return true;
        }
    }
}
