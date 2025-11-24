using NotificationService.NotificationService.Application.Contracts;
using NotificationService.NotificationService.Domain.Notifications;

namespace NotificationService.NotificationService.Application
{
    public class NotificationService(INotificationManagerResolver resolver, 
        INotificationRepository repository) : INotificationService
    {
        public Task<NotificationDto> CreateAsync(CreateNotificationInput input, CancellationToken cancellationToken)
        {
            var manager = resolver.Resolve(input.NotificationMethod);

            var result = await manager.
        }
    }
}
