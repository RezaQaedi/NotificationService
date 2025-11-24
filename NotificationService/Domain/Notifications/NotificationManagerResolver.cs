using Microsoft.Extensions.Options;
using NotificationService.Domain.Options;

namespace NotificationService.Domain.Notifications
{
    public class NotificationManagerResolver(IServiceProvider serviceProvider, 
        IOptions<NotificationServiceOptions> options) : INotificationManagerResolver
    {
        public INotificationManager Resolve(string notificationMethod)
        {
            return (INotificationManager)serviceProvider.GetRequiredService(
                options.Value.Providers[notificationMethod].NotificationManagerType);
        }
    }
}
