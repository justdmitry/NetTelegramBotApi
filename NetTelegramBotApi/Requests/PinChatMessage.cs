namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to add a message to the list of pinned messages in a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#pinchatmessage"/>
    /// </remarks>
    public class PinChatMessage() : RequestBase<bool>("pinChatMessage")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public required long MessageId { get; set; }

        public bool? DisableNotification { get; set; }
    }
}
