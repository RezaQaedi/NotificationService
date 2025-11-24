namespace NotificationService.Domain.Options
{
    public class NotificationServiceProviderConfigurations : Dictionary<string, NotificationServiceProviderConfiguration>
    {
        public void AddProvider(NotificationServiceProviderConfiguration providerConfiguration)
        {
            this[providerConfiguration.NotificationMethod] = providerConfiguration;
        }
    }
}
