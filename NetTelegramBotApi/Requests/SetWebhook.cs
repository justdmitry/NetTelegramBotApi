namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to specify a URL and receive incoming updates via an outgoing webhook.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#setwebhook"/>
    /// </remarks>
    public class SetWebhook() : RequestBase<bool>("setWebhook", true)
    {
        public required string Url { get; set; }

        public InputFile? Certificate { get; set; }

        public string? IpAddress { get; set; }

        public int? MaxConnections { get; set; }

        public string[]? AllowedUpdates { get; set; }

        public bool? DropPendingUpdates { get; set; }

        public string? SecretToken { get; set; }
    }
}
