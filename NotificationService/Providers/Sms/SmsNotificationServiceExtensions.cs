using NotificationService.Domain.Options;

namespace NotificationService.Providers.Sms
{
    public static class SmsNotificationServiceExtensions
    {
        public static IServiceCollection AddSms(this IServiceCollection services, IConfiguration configuration)
        {
           return services.AddTransient<SmsNotificationManager>()
                    .Configure<NotificationServiceOptions>(o =>
                    {
                        o.Providers.Add(new NotificationServiceProviderConfiguration(SmsNotificationConsts.MethodName,
                            typeof(SmsNotificationManager)));
                    });
        }
    }
}
