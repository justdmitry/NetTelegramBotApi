using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an animation file to be displayed in the message containing a game.
    /// </summary>
    public class Animation
    {
        /// <summary>
        /// Unique file identifier
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Optional. Animation thumbnail as defined by sender
        /// </summary>
        public PhotoSize Thumb { get; set; }

        /// <summary>
        /// Optional. Original animation filename as defined by sender
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
