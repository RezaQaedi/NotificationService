using NotificationService.Domain.Shared;
using Volo.Abp.Data;

namespace NotificationService.Providers.Mail
{
    public static class CreateNotificationModelExtensions
    {
        public const string Subject = "subject";
        public const string Body = "body";

        extension(CreateNotificationModel model)
        {
            public void SetSubject(string subject)
            {
                model.SetProperty(subject, subject);
            }

            public string? GetSubject()
            {
                return model.GetProperty(Subject)?.ToString();
            }

            public void SetBody(string body)
            {
                model.SetProperty(body, body);
            }

            public string? GetBody()
            {
                return model.GetProperty(Body)?.ToString();
            }
        }
    }
}
