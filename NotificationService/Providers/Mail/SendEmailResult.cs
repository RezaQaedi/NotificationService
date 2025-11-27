namespace NotificationService.Providers.Mail
{
    public class SendEmailResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public SendEmailResult()
        {
            Success = true;
        }

        public SendEmailResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
