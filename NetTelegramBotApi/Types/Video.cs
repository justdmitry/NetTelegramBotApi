namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#video"/>
    /// </remarks>
    public class Video
    {
        public string FileId { get; set; } = string.Empty;

        public string FileUniqueId { get; set; } = string.Empty;

        public int Width { get; set; }

        public int Height { get; set; }

        public int Duration { get; set; }

        public PhotoSize? Thumbnail { get; set; }

        public string? FileName { get; set; }

        public string? MimeType { get; set; }

        public long? FileSize { get; set; }
    }
}
