using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get current webhook status. Requires no parameters.
    /// On success, returns a WebhookInfo object.
    /// If the bot is using getUpdates, will return an object with the url field empty.
    /// </summary>
    public class GetWebhookInfo : RequestBase<WebhookInfo>
    {
        public GetWebhookInfo()
            : base("getWebhookInfo")
        {
            // Nothing
        }

        public override HttpContent CreateHttpContent()
        {
            return null;
        }
    }
}
