namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageentity"/>
    /// </remarks>
    public class MessageEntity
    {
        public MessageEntityType Type { get; set; }

        public int Offset { get; set; }

        public int Length { get; set; }

        public string? Url { get; set; }

        public User? User { get; set; }

        public string? Language { get; set; }

        public string? CustomEmojiId { get; set; }
    }
}
