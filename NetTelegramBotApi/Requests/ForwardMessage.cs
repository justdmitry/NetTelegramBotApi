namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to forward messages of any kind. Service messages and messages with protected content can't be forwarded. On success, the sent Message is returned.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#forwardmessage"/>
    /// </remarks>
    public class ForwardMessage() : RequestBase<Message>("forwardMessage")
    {
        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required IntegerOrString FromChatId { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public required long MessageId { get; set; }
    }
}
