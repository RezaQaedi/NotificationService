namespace NotificationService.Providers.Sms.SmsSenders.SmsDotIr
{
    public class SmsDotIrOptions
    {
        public const int TemplateId = 950192;
        public const string BaseUrl = "https://api.sms.ir/v1/";
        public const string VerifyMessage = "send/verify";
        public const string TemplatedIdKey = "TemplatedIdKey";
        public const string Key = "SMSDotir";

        public string ApiKey { get; set; }
    }
}
