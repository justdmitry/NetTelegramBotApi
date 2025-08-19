namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method when you need to tell the user that something is happening on the bot's side.
    /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status).
    /// Returns True on success.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendchataction"/>
    /// </remarks>
    public class SendChatAction() : RequestBase<bool>("sendChatAction")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required ChatAction Action { get; set; }
    }
}
