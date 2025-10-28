namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// The message was originally sent on behalf of a chat to a group chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageoriginchat"/>
    /// </remarks>
    public class MessageOriginChat : MessageOrigin
    {
        public Chat SenderChat { get; set; } = default!;

        public string? AuthorSignature { get; set; }
    }
}
