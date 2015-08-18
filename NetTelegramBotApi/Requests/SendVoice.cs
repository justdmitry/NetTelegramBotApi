using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. 
    /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Audio or Document). 
    /// On success, the sent Message is returned. 
    /// Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
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
        /// Duration of sent audio in seconds
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
