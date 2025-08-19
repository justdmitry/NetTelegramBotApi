namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to edit animation, audio, document, photo, or video messages, or to add media to text messages.
    /// On success, if the edited message is not an inline message, the edited Message is returned, otherwise True is returned.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#editmessagemedia"/>
    /// </remarks>
    public class EditMessageMedia() : RequestBase<Message>("editMessageMedia", true)
    {
        public string? BusinessConnectionId { get; set; }

        public IntegerOrString? ChatId { get; set; }

        public long? MessageId { get; set; }

        public string? InlineMessageId { get; set; }

        public required InputMedia Media { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }
    }
}
