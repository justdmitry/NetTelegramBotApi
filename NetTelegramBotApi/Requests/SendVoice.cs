using System;
using System.Globalization;
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
        public SendVoice(long chatId, FileToSend voice)
            : base(chatId, "sendVoice", "voice")
        {
            this.File = voice;
        }

        public SendVoice(string channelName, FileToSend voice)
            : base(channelName, "sendVoice", "voice")
        {
            this.File = voice;
        }

        /// <summary>
        /// Voice message caption, 0-200 characters.
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Duration of sent audio in seconds.
        /// </summary>
        public int? Duration { get; set; }

        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            if (!string.IsNullOrEmpty(Caption))
            {
                appendCallback("caption", Caption);
            }

            if (Duration.HasValue)
            {
                appendCallback("duration", Duration.Value.ToString(CultureInfo.InvariantCulture));
            }

            base.AppendParameters(appendCallback);
        }
    }
}
