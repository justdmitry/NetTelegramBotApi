namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object describes an update about a user stopping message generation.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messagegenerationstopped"/>
    /// </remarks>
    public class MessageGenerationStopped
    {
        public required Chat Chat { get; set; }

        public long? MessageThreadId { get; set; }

        public required long DraftId { get; set; }
    }
}
