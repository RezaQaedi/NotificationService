using NotificationService.Domain.Shared;

namespace NotificationService.Domain.Notifications
{
    public interface INotificationManager
    {
        Task<Notification> CreateAsync(CreateNotificationModel model, CancellationToken cancellationToken = default);
    }
}
