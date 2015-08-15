using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). 
    /// On success, the sent Message is returned. 
    /// Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendVideo : SendFileRequestBase<Message>
    {
        public SendVideo(long chatId, FileToSend photo)
            : base("sendVideo", "video")
        {
            this.ChatId = chatId;
            this.File = photo;
        }

        /// <summary>
        /// Duration of sent video in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Video caption (may also be used when resending videos by file_id).
        /// </summary>
        public string Caption { get; set; }
        
        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            if (Duration.HasValue)
            {
                appendCallback("duration", Duration.Value.ToString());
            }
            if (!string.IsNullOrEmpty(Caption))
            {
                appendCallback("caption", Caption);
            }

            base.AppendParameters(appendCallback);
        }
    }
}
