namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object contains information about one member of the chat.
    /// </summary>
    public class ChatMember
    {
        /// <summary>
        /// Information about the user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The member's status in the chat. Can be “creator”, “administrator”, “member”, “left” or “kicked”.
        /// </summary>
        public string Status { get; set; }

        public ChatMemberStatus GetStatus()
        {
            switch (Status)
            {
                case "creator":
                    return ChatMemberStatus.Creator;
                case "administrator":
                    return ChatMemberStatus.Administrator;
                case "member":
                    return ChatMemberStatus.Member;
                case "left":
                    return ChatMemberStatus.Left;
                case "kicked":
                    return ChatMemberStatus.Kicked;
                default:
                    return ChatMemberStatus.Unknown;
            }
        }
    }
}
