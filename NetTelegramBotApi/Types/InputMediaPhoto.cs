namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a photo to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputmediaphoto"/>
    /// </remarks>
    public class InputMediaPhoto : InputMedia
    {
        public override string Type { get; } = "photo";

        public required InputFileOrString Media { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? ShowCaptionAboveMedia { get; set; }

        public bool? HasSpoiler { get; set; }
    }
}
