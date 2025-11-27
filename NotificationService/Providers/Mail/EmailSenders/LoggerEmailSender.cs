namespace NotificationService.Providers.Mail.EmailSenders
{
    public class LoggerEmailSender(ILogger<LoggerEmailSender> logger) : IEmailSender
    {
        public Task<SendEmailResult> SendAsync(string to, string? subject, string? body, bool isBodyHtml = true,
            CancellationToken cancellationToken = default)
        {
            logger.LogInformation("Email just sent to {to} - {subject}, [{body}]", to, subject, body);

            return Task.FromResult(new SendEmailResult());
        }
    }
}
