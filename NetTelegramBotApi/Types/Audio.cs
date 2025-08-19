namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an audio file to be treated as music by the Telegram clients.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#audio"/>
    /// </remarks>
    public class Audio
    {
        public string FileId { get; set; } = string.Empty;

        public string FileUniqueId { get; set; } = string.Empty;

        public int Duration { get; set; }

        public string? Performer { get; set; }

        public string? Title { get; set; }

        public string? FileName { get; set; }

        public string? MimeType { get; set; }

        public long? FileSize { get; set; }

        public PhotoSize? Thumbnail { get; set; }
    }
}
