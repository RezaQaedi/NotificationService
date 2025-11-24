using NotificationService.Application.Contracts;

namespace NotificationService.Api.SendNotification
{
    public static class SendNotificationEndpoint
    {
        public static void AddRoute(IEndpointRouteBuilder app)
        {
            app.MapPost("/notification", async (SendNotificationRequest request, INotificationService notificationService, CancellationToken cancellationToken) => await notificationService.CreateAsync(new CreateNotificationInput
            {
                Delay = request.Delay, 
                NotificationMethod = request.NotificationMethod, 
                Message = request.Message, 
                Target = request.Target
            }, cancellationToken));
        }
    }

    public record SendNotificationRequest(string Target, string NotificationMethod, string Message, TimeSpan Delay);
}
