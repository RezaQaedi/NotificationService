namespace NotificationService.Providers.Sms
{
    public class SendSmsResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }

        public SendSmsResult()
        {
            Success = true;
        }

        public SendSmsResult(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}
