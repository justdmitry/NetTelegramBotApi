namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a chat member that was banned in the chat and can't return to the chat or view chat messages.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatmemberbanned"/>
    /// </remarks>
    public class ChatMemberBanned : ChatMember
    {
        public DateTimeOffset UntilDate { get; set; }
    }
}
