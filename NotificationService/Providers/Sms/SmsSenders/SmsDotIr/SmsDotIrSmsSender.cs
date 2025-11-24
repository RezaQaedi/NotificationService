using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace NotificationService.Providers.Sms.SmsSenders.SmsDotIr
{
    public class SmsDotIrSmsSender(IOptions<SmsDotIrOptions> options,
        ILogger<SmsDotIrSmsSender> logger,
        IHttpClientFactory httpClientFactory) : ISmsSender
    {
        public async Task<SendSmsResult> SendAsync(SmsMessage smsMessage, CancellationToken cancellationToken = default)
        {
            try
            {
                var configs = options.Value;
                var client = httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(SmsDotIrOptions.BaseUrl);
                client.DefaultRequestHeaders.Add("x-api-key", configs.ApiKey);

                var model = new VerifySendModel
                {
                    Mobile = smsMessage.PhoneNumber,
                    TemplateId = SmsDotIrOptions.TemplateId,
                    Parameters = smsMessage.Properties.Select(x =>
                        new VerifySendParameterModel { Name = x.Key, Value = x.Value.ToString() ?? string.Empty })
                        .ToArray()
                };

                var payload = JsonSerializer.Serialize(model);
                var stringContent = new StringContent(payload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(SmsDotIrOptions.VerifyMessage, stringContent, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

                    logger.LogError(
                        "Sms.ir response was not Success. response code : {code} - response content = {content}",
                        response.StatusCode, responseContent);
                }

                return response.IsSuccessStatusCode ? new SendSmsResult() : new SendSmsResult($"Send SMS result was not success : {response.StatusCode}");
            }
            catch (Exception ex)
            {
                var errorName = ex.GetType().Name;
                var errorNameDescription = errorName switch
                {
                    "UnauthorizedException" => "The provided token is not valid or access is denied.",
                    "LogicalException" => "Please check and correct the request parameters.",
                    "TooManyRequestException" => "The request count has exceeded the allowed limit.",
                    "UnexpectedException" or "InvalidOperationException" =>
                        "An unexpected error occurred on the remote server.",
                    _ => "Unable to send the request due to an unspecified error."
                };

                logger.LogError(
                    "There is a problem with the request. - Error: {errorName} - {errorNameDescription} - {ex.Message}",
                    errorName, errorNameDescription, ex.Message);

                return new SendSmsResult(errorNameDescription);
            }
        }
    }

    file class VerifySendParameterModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    file class VerifySendModel
    {
        public string Mobile { get; set; }

        public int TemplateId { get; set; }

        public VerifySendParameterModel[] Parameters { get; set; }
    }
}
