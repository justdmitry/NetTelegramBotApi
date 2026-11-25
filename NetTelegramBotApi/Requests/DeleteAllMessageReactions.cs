namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to remove up to 10000 recent reactions in a group or a supergroup chat added by a given user or chat.
    /// The bot must have the 'can_delete_messages' administrator right in the chat.
    /// Returns True on success.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#deleteallmessagereactions"/>.
    /// </remarks>
    public class DeleteAllMessageReactions() : RequestBase<bool>("deleteAllMessageReactions")
    {
        public required IntegerOrString ChatId { get; set; }

        public long? UserId { get; set; }

        public long? ActorChatId { get; set; }
    }
}
