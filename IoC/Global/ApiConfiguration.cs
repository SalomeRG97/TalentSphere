using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Auth.Interfaces.Repositories.Base;
using Auth.Repositories.Base;
using Interfaces.Utilities;
using Utilidades;
using Microsoft.Extensions.Hosting;
using Exceptions.MiddleWare;
using Hangfire;
using Microsoft.Extensions.Configuration;
using Admin.Services.Job;
using Hangfire.MySql;
using static Org.BouncyCastle.Math.EC.ECCurve;
using Hangfire.MemoryStorage;
using FluentValidation.AspNetCore;

namespace IoC.Global
{
    public class ApiConfiguration
    {
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            SerilogIoC.ConfigureSeqService(builder);
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IManejadorArchivosLocal, ManejadorArchivosLocal>();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpClient();
            builder.Services.AddHangfire(config =>
                config.UseMemoryStorage());

            builder.Services.AddHangfireServer();
        }
        public static void ConfigureApp(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHangfireDashboard();
            HangfireJobsConfigurator.ConfigureJobs(app.Services);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthorization();
            app.MapControllers();
            app.UseMiddleware<ExceptionMiddleware>();
            app.Run();
        }

    }
}
