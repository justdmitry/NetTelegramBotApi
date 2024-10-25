namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send general files.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#senddocument"/>
    /// </remarks>
    public class SendDocument() : RequestBase<Message>("sendDocument", true)
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required InputFileOrString Document { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? DisableContentTypeDetection { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public string? MessageEffectId { get; set; }

        public ReplyParameters? ReplyParameters { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }
    }
}
