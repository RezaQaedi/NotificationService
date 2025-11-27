using Volo.Abp.Data;

namespace NotificationService.Domain.Notifications
{
    public class Notification : IHasExtraProperties
    {
        public virtual Guid Id { get; protected set; }
        public virtual string Method { get; protected set; }
        public virtual bool? Success { get; protected set; }
        public string Target { get; protected set; }
        public string Message { get; protected set; }
        public virtual DateTime? CompletionTime { get; protected set; }
        public virtual string? FailureReason { get; protected set; }
        public virtual TimeSpan Delay { get; protected set; }

        protected Notification() { }

        public Notification(Guid id, string notificationMethod, string target, string message, TimeSpan delay = default)
        {
            Id = id;
            Method = notificationMethod;
            Target = target;
            Message = message;
            Delay = delay;

            ExtraProperties = new ExtraPropertyDictionary();
        }

        public void SetResult(bool success, string? failureReason = null)
        {
            if (CompletionTime.HasValue)
            {
                throw new NotificationHasBeenCompletedException();
            }

            CompletionTime = DateTime.UtcNow;
            Success = success;
            FailureReason = failureReason;
        }

        public ExtraPropertyDictionary ExtraProperties { get; protected set; }
    }
}
