namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to edit only the reply markup of messages.
    /// On success, if the edited message is not an inline message, the edited Message is returned, otherwise True is returned.
    /// </summary>
    /// <remarks>
    /// Note that business messages that were not sent by the bot and do not contain an inline keyboard
    /// can only be edited within 48 hours from the time they were sent.
    /// <seealso href="https://core.telegram.org/bots/api#editmessagereplymarkup"/>
    /// </remarks>
    public class EditMessageReplyMarkup() : RequestBase<Message>("editMessageReplyMarkup")
    {
        public string? BusinessConnectionId { get; set; }

        public IntegerOrString? ChatId { get; set; }

        public long? MessageId { get; set; }

        public string? InlineMessageId { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }
    }
}
