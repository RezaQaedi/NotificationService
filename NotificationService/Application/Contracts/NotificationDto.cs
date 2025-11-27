using Volo.Abp.Data;

namespace NotificationService.Application.Contracts
{
    public class NotificationDto : IHasExtraProperties
    {
        public Guid Id { get; set; }
        public string NotificationMethod { get; set; }
        public string Target { get; set; }
        public bool? Success { get; set; }
        public DateTime? CompletionTime { get; set; }
        public string? FailureReason { get; set; }
        public TimeSpan Delay { get; set; }
        public ExtraPropertyDictionary ExtraProperties { get; } = new();
    }
}
