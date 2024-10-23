namespace NetTelegramBotApi.Requests
{
    using System.Net.Http;

    public class DeleteWebhook : RequestBase<bool>
    {
        public DeleteWebhook()
            : base("deleteWebhook")
        {
            // Nothing
        }

        public override HttpContent CreateHttpContent()
        {
            return null;
        }
    }
}
