namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// As of v.4.0, Telegram clients support rounded square MPEG4 videos of up to 1 minute long. Use this method to send video messages.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendvideonote"/>
    /// </remarks>
    public class SendVideoNote() : RequestBase<Message>("sendVideoNote")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required InputFileOrString VideoNote { get; set; }

        public int? Duration { get; set; }

        public int? Length { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public string? MessageEffectId { get; set; }

        public ReplyParameters? ReplyParameters { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }

        protected override bool HaveFiles()
        {
            return VideoNote.InputFile != null || Thumbnail?.InputFile != null;
        }

        protected override void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            if (VideoNote.InputFile != null)
            {
                VideoNote = CreateAttachment(multipartFormDataContent, VideoNote.InputFile.Value);
            }

            if (Thumbnail != null && Thumbnail.Value.InputFile != null)
            {
                Thumbnail = CreateAttachment(multipartFormDataContent, Thumbnail.Value.InputFile.Value);
            }
        }
    }
}
