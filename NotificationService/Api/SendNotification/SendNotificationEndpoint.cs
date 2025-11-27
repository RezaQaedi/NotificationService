using NotificationService.Application.Contracts;
using Volo.Abp.Data;

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
                Target = request.Target,
                ExtraProperties = request.ExtraProperties
            }, cancellationToken));
        }
    }

    public class SendNotificationRequest(string target, string notificationMethod, string message, TimeSpan delay) : IHasExtraProperties
    {
        public string Target { get; init; } = target;
        public string NotificationMethod { get; init; } = notificationMethod;
        public string Message { get; init; } = message;
        public TimeSpan Delay { get; init; } = delay;
        public ExtraPropertyDictionary ExtraProperties { get; set; } = new();
    }
}
