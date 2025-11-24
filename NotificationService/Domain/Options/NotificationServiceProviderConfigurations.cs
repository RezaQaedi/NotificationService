namespace NotificationService.Domain.Options
{
    public class NotificationServiceProviderConfigurations : Dictionary<string, NotificationServiceProviderConfiguration>
    {
        public void Add(NotificationServiceProviderConfiguration providerConfiguration)
        {
            this[providerConfiguration.NotificationMethod] = providerConfiguration;
        }
    }
}
