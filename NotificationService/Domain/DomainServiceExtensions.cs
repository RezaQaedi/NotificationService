using NotificationService.Application.Contracts;
using NotificationService.Domain.Notifications;

namespace NotificationService.Domain
{
    public static class DomainServiceExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<INotificationManagerResolver, NotificationManagerResolver>();

            return services;
        }
    }
}
