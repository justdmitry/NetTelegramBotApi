namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a chat member that has no additional privileges or restrictions.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatmembermember"/>
    /// </remarks>
    public class ChatMemberMember : ChatMember
    {
        public User User { get; set; } = default!;

        public bool IsAnonymous { get; set; }

        public DateTimeOffset? UntilDate { get; set; }
    }
}
