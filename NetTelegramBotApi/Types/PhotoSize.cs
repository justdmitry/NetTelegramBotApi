namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one size of a photo or a file / sticker thumbnail.
    /// </summary>
    public class PhotoSize
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Photo width
        /// </summary>
        public long Width { get; set; }

        /// <summary>
        /// Photo height
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public long? FileSize { get; set; }
    }
}
