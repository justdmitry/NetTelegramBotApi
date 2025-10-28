namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// The message was originally sent to a channel chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageoriginchannel"/>
    /// </remarks>
    public class MessageOriginChannel : MessageOrigin
    {
        public Chat Chat { get; set; } = default!;

        public long MessageId { get; set; }

        public string? AuthorSignature { get; set; }
    }
}
