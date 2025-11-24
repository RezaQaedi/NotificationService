using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Notifications;

namespace NotificationService.EntityFrameworkCore
{
    public class NotificationServiceDbContext(DbContextOptions<NotificationServiceDbContext> options)
        : DbContext(options)
    {
        public DbSet<Notification> Notifications { get; set; }
    }
}
