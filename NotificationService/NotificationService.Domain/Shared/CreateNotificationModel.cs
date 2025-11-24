namespace NotificationService.NotificationService.Domain.Shared
{
    public class CreateNotificationModel
    {
        public string NotificationMethod { get; set; }
        public string Message { get; set; }
        public string Target { get; set; }
        public TimeSpan Delay { get; set; }
    }
}
