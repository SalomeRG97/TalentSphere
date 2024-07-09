using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin.Interfaces.Base;
using Admin.Interfaces.Repositories;
using Admin.Repositories.Base;
using Admin.Repositories.Repositories;
using Admin.Services.Master;
using Admin.Interfaces.Service.Master;

namespace IoC.Admin
{
    public class Admin_BussinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IArlRepository, ArlRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IArlService, ArlService>();
        }
    }
}