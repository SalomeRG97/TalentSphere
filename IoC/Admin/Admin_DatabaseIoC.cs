using Admin.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Admin
{
    public class Admin_DatabaseIoC
    {
        public static void ConfigureMySQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TalentSphereAdminContext>(
                (DbContextOptionsBuilder options) =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}