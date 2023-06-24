using Interfaces;
using LoggerService;

namespace AssayFinder.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigCors(this IServiceCollection services) => services.AddCors(opts =>
            opts.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader())
        );

        public static void ConfigLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
