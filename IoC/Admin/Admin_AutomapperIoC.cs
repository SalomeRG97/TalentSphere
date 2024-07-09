using Configuraciones.Automapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Admin
{
    public class Admin_AutomapperIoC
    {
        public static void ConfigureService(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(Admin_MappingProfile));
        }
    }
}
