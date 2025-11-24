using NotificationService.Application.Contracts;

namespace NotificationService.Application
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }
    }
}
