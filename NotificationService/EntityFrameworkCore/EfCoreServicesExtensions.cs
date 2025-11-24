using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Notifications;

namespace NotificationService.EntityFrameworkCore
{
    public static class EfCoreServicesExtensions
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NotificationServiceDbContext>(o => 
                o.UseSqlServer(configuration.GetConnectionString("NotificationService")));

            services.AddScoped<INotificationRepository, NotificationRepository>();

            return services;
        }
    }
}
