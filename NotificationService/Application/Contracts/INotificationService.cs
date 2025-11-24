namespace NotificationService.Application.Contracts
{
    public interface INotificationService
    {
        Task<NotificationDto> CreateAsync(CreateNotificationInput input, CancellationToken cancellationToken);
    }
}
