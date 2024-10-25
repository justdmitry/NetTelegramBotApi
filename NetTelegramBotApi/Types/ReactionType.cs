namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object contains full information about a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatfullinfo"/>
    /// </remarks>
    public class ReactionType
    {
        public ReactionTypeType Type { get; set; }

        public string? Emoji { get; set; }

        public string? CustomEmojiId { get; set; }
    }
}
