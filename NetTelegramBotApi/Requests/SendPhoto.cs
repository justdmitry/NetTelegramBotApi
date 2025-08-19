namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send photos. On success, the sent Message is returned.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendphoto"/>
    /// </remarks>
    public class SendPhoto() : RequestBase<Message>("sendPhoto", true)
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required InputFileOrString Photo { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? ShowCaptionAboveMedia { get; set; }

        public bool? HasSpoiler { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public string? MessageEffectId { get; set; }

        public ReplyParameters? ReplyParameters { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }
    }
}
