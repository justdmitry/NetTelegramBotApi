namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send video files, Telegram clients support MPEG4 videos (other formats may be sent as Document).
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendvideo"/>
    /// </remarks>
    public class SendVideo() : RequestBase<Message>("sendVideo", true)
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required InputFileOrString Video { get; set; }

        public int? Duration { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? ShowCaptionAboveMedia { get; set; }

        public bool? HasSpoiler { get; set; }

        public bool? SupportsStreaming { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public string? MessageEffectId { get; set; }

        public ReplyParameters? ReplyParameters { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }
    }
}
