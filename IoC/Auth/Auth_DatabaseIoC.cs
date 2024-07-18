using Auth.Entities.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC.Admin
{
    public class Auth_DatabaseIoC
    {
        public static void ConfigureMySQLService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TalentSphereAuthContext>(
                (DbContextOptionsBuilder options) =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
        }
    }
}