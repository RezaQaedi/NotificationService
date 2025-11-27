using NotificationService.Domain.Notifications;
using NotificationService.Domain.Shared;

namespace NotificationService.Providers.PushNotification
{
    public class PushNotificationManager : NotificationManagerBase, INotificationManager
    {
        protected override string MethodName { get; } = "PushNotification";

        public override Task<Notification> CreateAsync(CreateNotificationModel model, CancellationToken cancellationToken = default)
        {
            // Todo 
            throw new NotImplementedException();
        }
    }
}
