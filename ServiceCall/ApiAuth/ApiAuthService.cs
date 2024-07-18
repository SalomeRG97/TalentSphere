using Admin.DTO.ServiceCall;
using Admin.Interfaces.ServiceCall.ApiAuth;

namespace ServiceCall.ApiAuth
{
    public class ApiAuthService : HttpBase, IApiAuthService
    {
        public ApiAuthService(HttpClient httpClient) : base(httpClient)
        {
        }
        public async Task<bool> ActivarEmpleado(RequestActivarEmpleado request)
        {
            await Post<RequestActivarEmpleado, object>("DarAltaEmpleado", request);
            return true;
        }
        public async Task<bool> DarBajaEmpleado(RequestDesactivarEmpleado request)
        {
            await Post<RequestDesactivarEmpleado, object>("DarBajaEmpleado", request);
            return true;
        }
    }
}
