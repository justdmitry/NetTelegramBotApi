namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user
    /// (act as if the user has selected the bot‘s message and tapped ’Reply').
    /// This can be extremely useful if you want to create user-friendly step-by-step interfaces
    /// without having to sacrifice privacy mode.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#forcereply"/>
    /// </remarks>
    public class ForceReply : ReplyMarkupBase
    {
        public required bool Force { get; set; }

        public string? InputFieldPlaceholder { get; set; }

        public bool? Selective { get; set; }
    }
}
