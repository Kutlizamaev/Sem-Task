namespace CarFleet.HOST.Configuration
{
    public static class CorsConfiguration
    {
        public static IServiceCollection CorsRegister(this IServiceCollection services)
        {
            services.AddCors();

            return services;
        }

        public static WebApplication CorsConfigure(this WebApplication app)
        {
            app.UseCors(policy =>
            {
                policy
                .WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            return app;
        }
    }
}
