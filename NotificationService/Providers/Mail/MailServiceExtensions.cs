using NotificationService.Domain.Options;
using NotificationService.Providers.Mail.EmailSenders;

namespace NotificationService.Providers.Mail
{
    public static class MailServiceExtensions
    {
        public static IServiceCollection AddMail(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddTransient<MailNotificationManager>()
                .AddTransient<IEmailSender, LoggerEmailSender>()
                .Configure<NotificationServiceOptions>(o =>
                {
                    o.Providers.Add(new NotificationServiceProviderConfiguration(MailConsts.MethodName,
                        typeof(MailNotificationManager)));
                });
        }
        
    }
}
