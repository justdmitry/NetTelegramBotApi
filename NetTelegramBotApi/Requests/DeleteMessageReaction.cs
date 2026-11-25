namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to remove a reaction from a message in a group or a supergroup chat.
    /// The bot must have the 'can_delete_messages' administrator right in the chat.
    /// Returns True on success.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#deletemessagereaction"/>.
    /// </remarks>
    public class DeleteMessageReaction() : RequestBase<bool>("deleteMessageReaction")
    {
        public required IntegerOrString ChatId { get; set; }

        public required long MessageId { get; set; }

        public long? UserId { get; set; }

        public long? ActorChatId { get; set; }
    }
}
