using IoC.Global;
using IoC.Admin;
using Admin.Services.Job;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

Admin_AutomapperIoC.ConfigureService(builder);
Admin_DatabaseIoC.ConfigureMySQLService(builder);
Admin_BussinessLogicIoC.RepositoryService(builder);
Admin_BussinessLogicIoC.ReglasNegocioService(builder);
ApiConfiguration.ConfigureServices(builder);

var app = builder.Build();
// Verifica que el servicio IRecurringJobManager esté disponible
using (var scope = app.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    recurringJobManager.AddOrUpdate<DarAltaEmpleadoJob>("DarAltaEmpleadoJob", x => x.Execute(), Cron.Minutely);
    recurringJobManager.AddOrUpdate<DarBajaEmpleadoJob>("DarAltaEmpleadoJob", x => x.Execute(), Cron.Minutely);

}
ApiConfiguration.ConfigureApp(app);