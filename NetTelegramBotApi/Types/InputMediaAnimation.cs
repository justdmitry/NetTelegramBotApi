namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents an animation file (GIF or H.264/MPEG-4 AVC video without sound) to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputmediaanimation"/>
    /// </remarks>
    public class InputMediaAnimation : InputMedia
    {
        public override string Type { get; } = "animation";

        public required InputFileOrString Media { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? ShowCaptionAboveMedia { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? Duration { get; set; }

        public bool? HasSpoiler { get; set; }
    }
}
