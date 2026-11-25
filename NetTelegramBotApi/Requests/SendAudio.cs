namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send audio files, if you want Telegram clients to display them in the music player.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#sendaudio"/>
    /// </remarks>
    public class SendAudio() : RequestBase<Message>("sendAudio")
    {
        public string? BusinessConnectionId { get; set; }

        public required IntegerOrString ChatId { get; set; }

        public long? MessageThreadId { get; set; }

        public required InputFileOrString Audio { get; set; }

        public string? Caption { get; set; }

        public ParseMode? ParseMode { get; set; }

        public MessageEntity[]? CaptionEntities { get; set; }

        public int? Duration { get; set; }

        public string? Performer { get; set; }

        public string? Title { get; set; }

        public InputFileOrString? Thumbnail { get; set; }

        public bool? DisableNotification { get; set; }

        public bool? ProtectContent { get; set; }

        public string? MessageEffectId { get; set; }

        public ReplyParameters? ReplyParameters { get; set; }

        public ReplyMarkupBase? ReplyMarkup { get; set; }

        protected override bool HaveFiles()
        {
            return Audio.InputFile != null || Thumbnail?.InputFile != null;
        }

        protected override void CreateAttachments(MultipartFormDataContent multipartFormDataContent)
        {
            if (Audio.InputFile != null)
            {
                Audio = CreateAttachment(multipartFormDataContent, Audio.InputFile.Value);
            }

            if (Thumbnail != null && Thumbnail.Value.InputFile != null)
            {
                Thumbnail = CreateAttachment(multipartFormDataContent, Thumbnail.Value.InputFile.Value);
            }
        }
    }
}
