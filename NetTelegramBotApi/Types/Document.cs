namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a general file (as opposed to photos, voice messages and audio files).
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#document"/>
    /// </remarks>
    public class Document
    {
        public string FileId { get; set; } = string.Empty;

        public string FileUniqueId { get; set; } = string.Empty;

        public PhotoSize? Thumbnail { get; set; }

        public string? FileName { get; set; }

        public string? MimeType { get; set; }

        public long? FileSize { get; set; }
    }
}
