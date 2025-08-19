namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a voice note.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#voice"/>
    /// </remarks>
    public class Voice
    {
        public string FileId { get; set; } = string.Empty;

        public string FileUniqueId { get; set; } = string.Empty;

        public int Duration { get; set; }

        public string? MimeType { get; set; }

        public long? FileSize { get; set; }
    }
}
