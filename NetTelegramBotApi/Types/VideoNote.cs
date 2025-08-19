namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a video message (available in Telegram apps as of v.4.0).
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#videonote"/>
    /// </remarks>
    public class VideoNote
    {
        public string FileId { get; set; } = string.Empty;

        public string FileUniqueId { get; set; } = string.Empty;

        public int Length { get; set; }

        public int Duration { get; set; }

        public PhotoSize? Thumbnail { get; set; }

        public long? FileSize { get; set; }
    }
}
