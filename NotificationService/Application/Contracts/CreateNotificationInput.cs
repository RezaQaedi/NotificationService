namespace NotificationService.Application.Contracts
{
    public class CreateNotificationInput
    {
        public string Target { get; set; }
        public string NotificationMethod { get; set; }
        public string Message { get; set; }
        public TimeSpan Delay { get; set; }
    }
}
