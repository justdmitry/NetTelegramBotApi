using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a voice note.
    /// </summary>
    public class Voice
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
        /// Optional. Mime type of a file as defined by sender
        /// </summary>
        public string MimeType { get; set; }

        /// <summary>
        /// Optional. File size
        /// </summary>
        public long? FileSize { get; set; }
    }
}
