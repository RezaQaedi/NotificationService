using NotificationService.NotificationService.Domain.Shared;

namespace NotificationService.NotificationService.Domain.Notifications
{
    public abstract class NotificationManagerBase: INotificationManager
    {
        public abstract Task<Notification> CreateAsync(CreateNotificationModel model,
            CancellationToken cancellationToken = default);

        protected virtual Notification CreateNotifications(CreateNotificationModel model)
        {
            return new Notification(GenerateNewNotificationId(), model.NotificationMethod, model.Target, model.Message);
        }

        protected virtual Task SetNotificationResultAsync(Notification notification, bool success,
            string? failureReason = null)
        {
            notification.SetResult(success, failureReason);

            return Task.CompletedTask;
        }
        protected virtual Guid GenerateNewNotificationId()
        {
            return Guid.NewGuid();
        }
    }
}
