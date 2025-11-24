using NotificationService.Domain.Options;
using NotificationService.Providers.Sms.SmsSenders.SmsDotIr;
using NotificationService.Providers.Sms.SmsSenders.SmsLogger;

namespace NotificationService.Providers.Sms
{
    public static class SmsNotificationServiceExtensions
    {
        public static IServiceCollection AddSms(this IServiceCollection services, IConfiguration configuration)
        {
           return services.AddTransient<SmsNotificationManager>()
                    .AddTransient<ISmsSender, SmsLoggerSmsSender>()
                    .AddHttpClient()
                    .Configure<SmsDotIrOptions>(configuration.GetSection("SmsSenders").GetSection(SmsDotIrOptions.Key))
                    .Configure<NotificationServiceOptions>(o =>
                    {
                        o.Providers.Add(new NotificationServiceProviderConfiguration(SmsNotificationConsts.MethodName,
                            typeof(SmsNotificationManager)));
                    });
        }
    }
}
