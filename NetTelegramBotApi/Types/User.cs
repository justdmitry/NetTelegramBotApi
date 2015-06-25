using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    public class User : ChatBase
    {
        /// <summary>
        /// User‘s or bot’s first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. User‘s or bot’s last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. User‘s or bot’s username
        /// </summary>
        public string Username { get; set; }
    }
}
