namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to remove webhook integration if you decide to switch back to getUpdates. Returns True on success.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#deletewebhook"/>
    /// </remarks>
    public class DeleteWebhook() : RequestBase<bool>("deleteWebhook")
    {
        public bool? DropPendingUpdates { get; set; }
    }
}
