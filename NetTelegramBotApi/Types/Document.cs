using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a general file (as opposed to photos and audio files). 
    /// Telegram users can send files of any type of up to 1.5 GB in size.
    /// </summary>
    /// <remarks>
    /// A missing thumbnail for a file (or sticker) is presented as an empty object. 
    /// </remarks>
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
