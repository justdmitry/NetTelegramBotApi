namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    public class Video
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Video width as defined by sender
        /// </summary>
        public long Width { get; set; }

        /// <summary>
        /// Video height as defined by sender
        /// </summary>
        public long Height { get; set; }

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
        public long Duration { get; set; }

        /// <summary>
        /// Video thumbnail
        /// </summary>
        public PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Mime type of a file as defined by sender
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public long? FileSize { get; set; }
    }
}
