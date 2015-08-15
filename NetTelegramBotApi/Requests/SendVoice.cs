using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). 
    /// On success, the sent Message is returned. 
    /// Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendVoice : SendFileRequestBase<Message>
    {
        public SendVoice(long chatId, FileToSend audio)
            : base("sendVoice", "audio")
        {
            this.ChatId = chatId;
            this.File = audio;
        }

        /// <summary>
        /// Duration of sent video in seconds
        /// </summary>
        public int? Duration { get; set; }

        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            if (Duration.HasValue)
            {
                appendCallback("duration", Duration.Value.ToString());
            }

            base.AppendParameters(appendCallback);
        }
    }
}
