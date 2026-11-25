namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send animation files (GIF or H.264/MPEG-4 AVC video without sound).
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendanimation"/>
    /// </remarks>
    public class SendAnimation() : RequestBase<Message>("sendAnimation")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required InputFileOrString Animation { get; set; }

        public int? Duration { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

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

        protected override bool HaveFiles()
        {
            return Animation.InputFile != null || Thumbnail?.InputFile != null;
        }

        protected override void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            if (Animation.InputFile != null)
            {
                Animation = CreateAttachment(multipartFormDataContent, Animation.InputFile.Value);
            }

            if (Thumbnail != null && Thumbnail.Value.InputFile != null)
            {
                Thumbnail = CreateAttachment(multipartFormDataContent, Thumbnail.Value.InputFile.Value);
            }
        }
    }
}
