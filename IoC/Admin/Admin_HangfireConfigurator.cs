using Admin.Services.Job;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;

public class HangfireJobsConfigurator
{
    public static void ConfigureJobs(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

            recurringJobManager.AddOrUpdate<DarAltaEmpleadoJob>("DarAltaEmpleadoJob", x => x.Execute(), Cron.Minutely);
            recurringJobManager.AddOrUpdate<DarBajaEmpleadoJob>("DarBajaEmpleadoJob", x => x.Execute(), Cron.Minutely);
        }
    }
}
