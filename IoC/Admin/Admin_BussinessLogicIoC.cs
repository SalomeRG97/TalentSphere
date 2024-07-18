using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Admin.Interfaces.Base;
using Admin.Interfaces.Repositories;
using Admin.Interfaces.Utilities;
using Admin.Repositories.Base;
using Admin.Repositories.Repositories;
using Admin.Services.Master;
using Admin.Interfaces.Service.Master;
using Utilidades;
using Utilidades.ApiAuth;
using Admin.Interfaces.Utilities.ApiAuth;

namespace IoC.Admin
{
    public class Admin_BussinessLogicIoC
    {
        public static void RepositoryService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IArlRepository, ArlRepository>();
            builder.Services.AddScoped<ICargoRepository, CargoRepository>();
            builder.Services.AddScoped<ICecoRepository, CecoRepository>();
            builder.Services.AddScoped<IEpsRepository, EpsRepository>();
            builder.Services.AddScoped<IServicioRepository, ServicioRepository>();
            builder.Services.AddScoped<IFondoPensionRepository, FondoPensionRepository>();
            builder.Services.AddScoped<ITipoContratoRepository, TipoContratoRepository>();
            builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            builder.Services.AddScoped<IContratoLaboralRepository, ContratoLaboralRepository>();
            builder.Services.AddScoped<IFilesRecordRepository, FilesRecordRepository>();
        }
        public static void ReglasNegocioService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IArlService, ArlService>();
            builder.Services.AddScoped<ICargoService, CargoService>();
            builder.Services.AddScoped<ICecoService, CecoService>();
            builder.Services.AddScoped<IEpsService, EpsService>();
            builder.Services.AddScoped<IFondoPensionService, FondoPensionService>();
            builder.Services.AddScoped<IServicioService, ServicioService>();
            builder.Services.AddScoped<ITipoContratoService, TipoContratoService>();
            builder.Services.AddScoped<IFilesRecordService, FilesRecordService>();
            builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
            builder.Services.AddScoped<IHttpBase, HttpBase>();
            builder.Services.AddHttpClient<IApiAuthService, ApiAuthService>(service =>
            {
                service.BaseAddress = new Uri(builder.Configuration.GetSection("ApiAuth").Value);
            });

        }
        public static void UtilidadesService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IManejadorArchivosLocal, ManejadorArchivosLocal>();
        }
    }
}