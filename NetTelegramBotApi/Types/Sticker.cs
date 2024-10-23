namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    public class Sticker
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Sticker width
        /// </summary>
        public long Width { get; set; }

        /// <summary>
        /// Sticker height
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// Sticker thumbnail in .webp or .jpg format
        /// </summary>
        public PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Emoji associated with the sticker
        /// </summary>
        public string Emoji { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public long? FileSize { get; set; }
    }
}
