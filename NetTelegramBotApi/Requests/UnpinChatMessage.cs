namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to remove a message from the list of pinned messages in a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#unpinchatmessage"/>
    /// </remarks>
    public class UnpinChatMessage() : RequestBase<bool>("unpinChatMessage")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageId { get; set; }
    }
}
