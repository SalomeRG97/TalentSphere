using Admin.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Admin
{
    public class Admin_DatabaseIoC
    {
        public static void ConfigureSqlServerService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TalentSphereAdminContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
