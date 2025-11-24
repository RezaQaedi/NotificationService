namespace NotificationService.Providers.Sms.SmsSenders.SmsLogger
{
    public class SmsLoggerSmsSender(ILogger<SmsLoggerSmsSender> logger) : ISmsSender
    {
        public Task<SendSmsResult> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Sms sent to {phoneNumber}, with content of {text}", smsMessage.PhoneNumber, smsMessage.Text);

            return Task.FromResult(new SendSmsResult());
        }
    }
}
