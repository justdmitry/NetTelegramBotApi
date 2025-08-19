namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents an audio file to be treated as music to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputmediaaudio"/>
    /// </remarks>
    public class InputMediaAudio : InputMedia
    {
        public override string Type { get; } = "audio";

        public required InputFileOrString Media { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public int? Duration { get; set; }

        public string? Performer { get; set; }

        public string? Title { get; set; }
    }
}
