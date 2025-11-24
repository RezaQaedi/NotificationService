using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Notifications;

namespace NotificationService.EntityFrameworkCore
{
    public class NotificationRepository(NotificationServiceDbContext dbContext) : INotificationRepository
    {
        public async Task<Notification> UpdateAsync(Notification notification, CancellationToken cancellationToken = default)
        {
            dbContext.Update(notification);

            await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

            return notification;
        }

        public async Task<Notification> InsertAsync(Notification notification, CancellationToken cancellationToken = default)
        {
            dbContext.Add(notification);

            await dbContext.SaveChangesAsync(cancellationToken: cancellationToken);

            return notification;
        }
    }
}
