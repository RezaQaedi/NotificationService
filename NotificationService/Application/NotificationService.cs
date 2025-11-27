using NotificationService.Application.Contracts;
using NotificationService.Domain.Notifications;
using NotificationService.Domain.Shared;
using Volo.Abp.ObjectExtending;

namespace NotificationService.Application
{
    public class NotificationService(INotificationManagerResolver resolver,
        INotificationRepository repository) : INotificationService
    {
        public async Task<NotificationDto> CreateAsync(CreateNotificationInput input, CancellationToken cancellationToken)
        {
            var manager = resolver.Resolve(input.NotificationMethod);

            var createModel = new CreateNotificationModel(input.NotificationMethod, input.Message, input.Target, input.Delay);
            input.MapExtraPropertiesTo(createModel, MappingPropertyDefinitionChecks.None); // don't do MappingPropertyDefinitionChecks.None in production

            var notification = await manager.CreateAsync(createModel, cancellationToken);
            
            return MapToDto(await repository.InsertAsync(notification, cancellationToken));
        }

        private static NotificationDto MapToDto(Notification notification)
        {
            var dto = new NotificationDto()
            {
                NotificationMethod = notification.Method,
                Target = notification.Target,
                CompletionTime = notification.CompletionTime,
                FailureReason = notification.FailureReason,
                Id = notification.Id,
                Success = notification.Success,
                Delay = notification.Delay
            };

            notification.MapExtraPropertiesTo(dto, MappingPropertyDefinitionChecks.None);

            return dto;
        }
    }
}
