namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a general file (as opposed to photos, voice messages and audio files).
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Unique file identifier
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Document thumbnail as defined by sender
        /// </summary>
        public PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Original filename as defined by sender
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Optional. MIME type of the file as defined by sender
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public long? FileSize { get; set; }
    }
}
