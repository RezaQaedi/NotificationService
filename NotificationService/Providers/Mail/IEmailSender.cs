namespace NotificationService.Providers.Mail
{
    public interface IEmailSender
    {
        Task<SendEmailResult> SendAsync(
            string to,
            string? subject,
            string? body,
            bool isBodyHtml = true,
            CancellationToken cancellationToken = default);
    }
}
