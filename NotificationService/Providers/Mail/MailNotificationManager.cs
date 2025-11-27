using NotificationService.Domain.Notifications;
using NotificationService.Domain.Shared;
using Volo.Abp.Data;

namespace NotificationService.Providers.Mail
{
    public class MailNotificationManager(IEmailSender emailSender) : NotificationManagerBase, INotificationManager
    {
        protected override string MethodName => MailConsts.MethodName;

        public override async Task<Notification> CreateAsync(CreateNotificationModel model, CancellationToken cancellationToken = default)
        {
            var result = await emailSender.SendAsync(model.Target, model.GetSubject(), model.GetBody(), cancellationToken: cancellationToken);
            var notification = CreateNotifications(model);
            notification.SetResult(result.Success, result.ErrorMessage);

            return notification;
        }

        protected override Notification CreateNotifications(CreateNotificationModel model)
        {
            var result = base.CreateNotifications(model);

            result.SetProperty(CreateNotificationModelExtensions.Body, model.GetBody());
            result.SetProperty(CreateNotificationModelExtensions.Subject, model.GetSubject());

            return result;
        }
    }
}
