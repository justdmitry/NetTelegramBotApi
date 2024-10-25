namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a chat member that isn't currently a member of the chat, but may join it themselves.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatmemberleft"/>
    /// </remarks>
    public class ChatMemberLeft : ChatMember
    {
        public User User { get; set; } = default!;
    }
}
