namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a phone contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Contact's phone number.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Contact's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Optional. Contact's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Optional. Contact's user identifier in Telegram.
        /// </summary>
        public long UserId { get; set; }
    }
}
