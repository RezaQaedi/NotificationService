namespace NotificationService.Domain.Options
{
    public class NotificationServiceOptions
    {
        public NotificationServiceProviderConfigurations Providers { get; set; } = new();
    }
}
