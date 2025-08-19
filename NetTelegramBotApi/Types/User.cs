namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#user"/>
    /// </remarks>
    public class User
    {
        public long Id { get; set; }

        public bool IsBot { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public string? LanguageCode { get; set; }

        public bool? IsPremium { get; set; }

        public bool? AddedToAttachmentMenu { get; set; }

        public bool? CanJoinGroups { get; set; }

        public bool? CanReadAllGroupMessages { get; set; }

        public bool? SupportsInlineQueries { get; set; }

        public bool? CanConnectToBusiness { get; set; }

        public bool? HasMainWebApp { get; set; }
    }
}
