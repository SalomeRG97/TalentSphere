using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Auth.Interfaces.Repositories.Base;
using Auth.Repositories.Base;
using Interfaces.Utilities;
using Utilidades;
using Microsoft.Extensions.Hosting;
using Exceptions.MiddleWare;

namespace IoC.Global
{
    public class ApiConfiguration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            SerilogIoC.ConfigureSeqService(builder);
            //Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IManejadorArchivosLocal, ManejadorArchivosLocal>();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
        }
        public static void ConfigureApp(WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

    }
}
