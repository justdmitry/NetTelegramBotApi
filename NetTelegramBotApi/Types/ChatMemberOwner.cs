namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a chat member that owns the chat and has all administrator privileges.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatmemberowner"/>
    /// </remarks>
    public class ChatMemberOwner : ChatMember
    {
        public bool IsAnonymous { get; set; }

        public string? CustomTitle { get; set; }
    }
}
