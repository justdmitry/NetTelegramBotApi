namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a general file to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputmediadocument"/>
    /// </remarks>
    public class InputMediaDocument : InputMedia
    {
        public override string Type { get; } = "document";

        public required InputFileOrString Media { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public bool? DisableContentTypeDetection { get; set; }

        public override bool HaveFiles()
        {
            return Media.InputFile != null || Thumbnail?.InputFile != null;
        }

        public override void CreateAttachments(MultipartFormDataContent multipartFormDataContent, string? fixedId = null)
        {
            if (Media.InputFile != null)
            {
                Media = RequestBase<object>.CreateAttachment(multipartFormDataContent, Media, fixedId);
            }

            if (Thumbnail != null && Thumbnail.Value.InputFile != null)
            {
                Thumbnail = RequestBase<object>.CreateAttachment(multipartFormDataContent, Thumbnail.Value, fixedId);
            }
        }
    }
}
