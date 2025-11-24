namespace NotificationService.Providers.Sms
{
    public interface ISmsSender
    {
        Task<SendSmsResult> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default);
    }
}
