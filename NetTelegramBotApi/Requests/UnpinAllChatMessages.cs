namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to clear the list of pinned messages in a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#unpinallchatmessages"/>
    /// </remarks>
    public class UnpinAllChatMessages() : RequestBase<bool>("unpinAllChatMessages")
    {
        public required IntegerOrString ChatId { get; set; }
    }
}
