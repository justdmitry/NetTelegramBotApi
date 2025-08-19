namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object contains information about one member of a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatmember"/>
    /// </remarks>
    public class ChatMember
    {
        public ChatMemberStatus Status { get; set; }

        public User User { get; set; } = default!;
    }
}
