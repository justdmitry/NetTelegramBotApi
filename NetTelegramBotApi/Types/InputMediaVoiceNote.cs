namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a voice message file to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inputmediavoicenote"/>
    /// </remarks>
    public class InputMediaVoiceNote : InputMedia
    {
        public override string Type { get; } = "voice_note";

        public required InputFileOrString Media { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public int? Duration { get; set; }

        public override bool HaveFiles()
        {
            return Media.InputFile != null;
        }

        public override void CreateAttachments(MultipartFormDataContent multipartFormDataContent, string? fixedId = null)
        {
            if (Media.InputFile != null)
            {
                Media = RequestBase<object>.CreateAttachment(multipartFormDataContent, Media, fixedId);
            }
        }
    }
}
