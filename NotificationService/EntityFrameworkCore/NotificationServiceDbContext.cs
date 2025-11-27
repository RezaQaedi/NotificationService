using Microsoft.EntityFrameworkCore;
using NotificationService.Domain.Notifications;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace NotificationService.EntityFrameworkCore
{
    public class NotificationServiceDbContext(DbContextOptions<NotificationServiceDbContext> options)
        : DbContext(options)
    {
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>(o =>
            {
                o.ConfigureByConvention();
                o.ApplyObjectExtensionMappings();
            });


            modelBuilder.TryConfigureObjectExtensions<NotificationServiceDbContext>();
        }
    }
}
