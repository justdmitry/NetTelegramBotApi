using System;
using System.Globalization;
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
        public SendVideo(long chatId, FileToSend video) 
            : base(chatId, "sendVideo", "video")
        {
            this.File = video;
        }
        public SendVideo(string channelName, FileToSend video)
            : base(channelName, "sendVideo", "video")
        {
            this.File = video;
        }

        /// <summary>
        /// Duration of sent video in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Video width
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// Video height
        /// </summary>
        public int? Height { get; set; }

        /// <summary>
        /// Video caption (may also be used when resending videos by file_id), 0-200 characters
        /// </summary>
        public string Caption { get; set; }

        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            if (Duration.HasValue)
            {
                appendCallback("duration", Duration.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (Width.HasValue)
            {
                appendCallback("width", Width.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (Height.HasValue)
            {
                appendCallback("height", Height.Value.ToString(CultureInfo.InvariantCulture));
            }
            if (!string.IsNullOrEmpty(Caption))
            {
                appendCallback("caption", Caption);
            }

            base.AppendParameters(appendCallback);
        }
    }
}
