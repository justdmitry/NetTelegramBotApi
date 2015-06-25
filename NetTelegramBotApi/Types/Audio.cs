using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an audio file (voice note).
    /// </summary>
    public class Audio
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        public string FileId { get; set; }

        /// <summary>
        /// Duration of the audio in seconds as defined by sender
        /// </summary>
        public long Duration { get; set; }

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
