using Volo.Abp.Data;

namespace NotificationService.Application.Contracts
{
    public class CreateNotificationInput : IHasExtraProperties
    {
        public string Target { get; set; }
        public string NotificationMethod { get; set; }
        public string Message { get; set; }
        public TimeSpan Delay { get; set; }
        public ExtraPropertyDictionary ExtraProperties { get; set; } = new();
    }
}
