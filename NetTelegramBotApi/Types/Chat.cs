namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chat"/>
    /// </remarks>
    public class Chat
    {
        public long Id { get; set; }

        public ChatType Type { get; set; }

        public string? Title { get; set; }

        public string? Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public bool? IsForum { get; set; }
    }
}
