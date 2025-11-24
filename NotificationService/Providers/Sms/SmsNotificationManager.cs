using NotificationService.Domain.Notifications;
using NotificationService.Domain.Shared;

namespace NotificationService.Providers.Sms
{
    public class SmsNotificationManager(ISmsSender smsSender) : NotificationManagerBase
    {
        protected override string MethodName => SmsNotificationConsts.MethodName;

        public override async Task<Notification> CreateAsync(CreateNotificationModel model, CancellationToken cancellationToken = default)
        {
            // Todo : handle delay
            // Todo : handle model params

            var notification = base.CreateNotifications(model);

            var result = await smsSender.SendAsync(new SmsMessage(model.Target, model.Message), cancellationToken);

            notification.SetResult(result.Success, result.ErrorMessage);

            return notification;
        }
    }
}
