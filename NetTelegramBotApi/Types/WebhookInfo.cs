namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes the current status of a webhook.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#webhookinfo"/>
    /// </remarks>
    public class WebhookInfo
    {
        public string? Url { get; set; }

        public bool HasCustomCertificate { get; set; }

        public int PendingUpdateCount { get; set; }

        public string? IpAddress { get; set; }

        public DateTimeOffset? LastErrorDate { get; set; }

        public string? LastErrorMessage { get; set; }

        public DateTimeOffset? LastSynchronizationErrorDate { get; set; }

        public int? MaxConnections { get; set; }

        public string[]? AllowedUpdates { get; set; }
    }
}
