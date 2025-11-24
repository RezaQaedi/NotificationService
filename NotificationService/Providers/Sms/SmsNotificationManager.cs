using NotificationService.Domain.Notifications;
using NotificationService.Domain.Shared;

namespace NotificationService.Providers.Sms
{
    public class SmsNotificationManager : NotificationManagerBase
    {
        protected override string MethodName => SmsNotificationConsts.MethodName;

        public override Task<Notification> CreateAsync(CreateNotificationModel model, CancellationToken cancellationToken = default)
        {
            var notification = base.CreateNotifications(model);
            // resolve sms sender 
            // try to send sms
            // set the result 

            notification.SetResult(true);

            return Task.FromResult(notification);
        }
    }
}
