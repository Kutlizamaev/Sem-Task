using CarFleet.BLL.Services;
using CarFleet.DAL.Entities;
using CarFleet.DAL.Repositories;
using CarFleet.DAL.Repositories.Interfaces;

namespace CarFleet.HOST.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection ServicesRegister(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddAntiforgery(o => o.HeaderName = "X-XSRF-TOKEN");

            services.AddScoped<JwtService>();

            services.AddScoped<VehicleService>();
            services.AddScoped<OrdersService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<FirebaseService>();
            services.AddScoped<EmailService>();

            services.AddScoped<IVehicleRepository<Vehicle>, VehicleRepository>();
            services.AddScoped<IOrdersRepository<BookingOrder>, OrdersRepository>();
            services.AddScoped<ICategoryRepository<VehicleCategory>, CategoryRepository>();

            return services;
        }
    }
}
