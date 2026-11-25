namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a video to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputmediavideo"/>
    /// </remarks>
    public class InputMediaVideo : InputMedia
    {
        public override string Type { get; } = "video";

        public required InputFileOrString Media { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public InputFileOrString? Cover { get; set; }

        public DateTimeOffset? StartTimestamp { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? ShowCaptionAboveMedia { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? Duration { get; set; }

        public bool? SupportsStreaming { get; set; }

        public bool? HasSpoiler { get; set; }

        public override bool HaveFiles()
        {
            return Media.InputFile != null || Cover?.InputFile != null;
        }

        public override void CreateAttachments(MultipartFormDataContent multipartFormDataContent, string? fixedId = null)
        {
            if (Media.InputFile != null)
            {
                Media = RequestBase<object>.CreateAttachment(multipartFormDataContent, Media, fixedId);
            }

            if (Cover != null && Cover.Value.InputFile != null)
            {
                Cover = RequestBase<object>.CreateAttachment(multipartFormDataContent, Cover.Value, fixedId);
            }
        }
    }
}
