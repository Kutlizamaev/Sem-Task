using CarFleet.DAL;
using Microsoft.EntityFrameworkCore;

namespace CarFleet.HOST.Configuration
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection DataBaseRegister(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(config["ConnectionStrings:DefaultConnection"]));

            return services;
        }
    }
}
