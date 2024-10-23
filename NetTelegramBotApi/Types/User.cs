namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier for this user, or bot, or group chat
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// True, if this user is a bot.
        /// </summary>
        public bool IsBot { get; set; }

        /// <summary>
        /// User's or bot's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. User's or bot's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. User's or bot's username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Optional. IETF language tag of the user's language
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// Optional. True, if this user is a Telegram Premium user.
        /// </summary>
        public bool IsPremium { get; set; }

        /// <summary>
        /// Optional. True, if this user added the bot to the attachment menu.
        /// </summary>
        public bool AddedToAttachmentMenu { get; set; }

        /// <summary>
        /// Optional. True, if the bot can be invited to groups. Returned only in getMe.
        /// </summary>
        public bool CanJoinGroups { get; set; }

        /// <summary>
        /// Optional. True, if privacy mode is disabled for the bot. Returned only in getMe.
        /// </summary>
        public bool CanReadAllGroupMessages { get; set; }

        /// <summary>
        /// Optional. True, if the bot supports inline queries. Returned only in getMe.
        /// </summary>
        public bool SupportsInlineQueries { get; set; }
    }
}
