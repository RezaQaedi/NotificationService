namespace NotificationService.Domain.Notifications
{
    public interface INotificationRepository
    {
        Task<Notification> UpdateAsync(Notification notification, CancellationToken cancellationToken = default);
        Task<Notification> InsertAsync(Notification  notification, CancellationToken cancellationToken = default);
    }
}
