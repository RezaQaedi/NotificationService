using Volo.Abp.Data;

namespace NotificationService.Domain.Shared
{
    public class CreateNotificationModel(string notificationMethod, string message, string target, TimeSpan delay = default) : IHasExtraProperties
    {
        public string NotificationMethod { get; init; } = notificationMethod;
        public string Message { get; init; } = message;
        public string Target { get; init; } = target;
        public TimeSpan Delay { get; init; } = delay;
        public ExtraPropertyDictionary ExtraProperties { get; } = new();
    }
}
