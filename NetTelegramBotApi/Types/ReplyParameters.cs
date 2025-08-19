namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes reply parameters for the message that is being sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#replyparameters"/>
    /// </remarks>
    public class ReplyParameters
    {
        public required long MessageId { get; set; }

        public string? ChatId { get; set; }

        public bool? AllowSendingWithoutReply { get; set; }

        public string? Quote { get; set; }

        public ParseMode? QuoteParseMode { get; set; }

        public MessageEntity[]? QuoteEntities { get; set; }

        public int? QuotePosition { get; set; }
    }
}
