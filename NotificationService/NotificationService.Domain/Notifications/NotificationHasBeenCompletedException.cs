namespace NotificationService.NotificationService.Domain.Notifications
{
    public class NotificationHasBeenCompletedException : Exception
    {
        public NotificationHasBeenCompletedException() 
            : base("The notification has been completed.")
        {
        }
    }
}
