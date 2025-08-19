namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get current webhook status.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getwebhookinfo"/>
    /// </remarks>
    public class GetWebhookInfo() : RequestBase<WebhookInfo>("getWebhookInfo")
    {
        // Nothing.
    }
}
