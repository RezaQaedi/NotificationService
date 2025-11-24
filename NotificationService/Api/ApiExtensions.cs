using NotificationService.Api.SendNotification;

namespace NotificationService.Api
{
    public static class ApiExtensions
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            SendNotificationEndpoint.AddRoute(app);
            return app;
        }
    }
}
