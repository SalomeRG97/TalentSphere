using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Auth.Interfaces.Repositories.Base;
using Auth.Interfaces.Repositories.Repositories;
using Auth.Services;
using Auth.Interfaces.Services;
using Auth.Repositories.Base;
using Auth.Repositories.Repositories;

namespace IoC.Auth
{
    public class Auth_BussinessLogicIoC
    {

        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
