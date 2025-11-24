namespace NotificationService.NotificationService.Domain.Notifications
{
    public interface INotificationManagerResolver
    {
        INotificationManager Resolve(string notificationMethod);
    }
}
