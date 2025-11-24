using NotificationService.NotificationService.Domain.Shared;

namespace NotificationService.NotificationService.Domain.Notifications
{
    public interface INotificationManager
    {
        Task<Notification> CreateAsync(CreateNotificationModel model, CancellationToken cancellationToken = default);
    }
}
