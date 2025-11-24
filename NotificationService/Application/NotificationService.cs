using NotificationService.Application.Contracts;
using NotificationService.Domain.Notifications;
using NotificationService.Domain.Shared;

namespace NotificationService.Application
{
    public class NotificationService(INotificationManagerResolver resolver,
        INotificationRepository repository) : INotificationService
    {
        public async Task<NotificationDto> CreateAsync(CreateNotificationInput input, CancellationToken cancellationToken)
        {
            var manager = resolver.Resolve(input.NotificationMethod);

            var result = await manager.CreateAsync(new
                CreateNotificationModel(input.NotificationMethod, input.Message, input.Target, input.Delay), cancellationToken);

            return MapToDto(await repository.InsertAsync(result, cancellationToken));
        }

        private static NotificationDto MapToDto(Notification notification)
            => new()
            {
                NotificationMethod = notification.Method,
                Target = notification.Target,
                CompletionTime = notification.CompletionTime,
                FailureReason = notification.FailureReason,
                Id = notification.Id,
                Success = notification.Success,
                Delay = notification.Delay
            };
    }
}
