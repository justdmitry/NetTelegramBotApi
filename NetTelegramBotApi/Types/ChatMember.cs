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
            return Status switch
            {
                "creator" => ChatMemberStatus.Creator,
                "administrator" => ChatMemberStatus.Administrator,
                "member" => ChatMemberStatus.Member,
                "left" => ChatMemberStatus.Left,
                "kicked" => ChatMemberStatus.Kicked,
                _ => ChatMemberStatus.Unknown,
            };
        }
    }
}
