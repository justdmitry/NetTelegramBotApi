using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. 
    /// For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Document). 
    /// On success, the sent Message is returned. 
    /// Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendAudio : SendFileRequestBase<Message>
    {
        public SendAudio(long chatId, FileToSend photo) 
            : base("sendAudio", "audio")
        {
            this.ChatId = chatId;
            this.File = photo;
        }

        /// <summary>
        /// Duration of sent audio in seconds
        /// </summary>
        public int? Duration { get; set; }

        /// <summary>
        /// Performer of sent audio
        /// </summary>
        public string Performer { get; set; }

        /// <summary>
        /// Title of sent audio
        /// </summary>
        public string Title { get; set; }
        
        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            if (Duration.HasValue)
            {
                appendCallback("duration", Duration.Value.ToString());
            }
            if (!string.IsNullOrEmpty(Performer))
            {
                appendCallback("performer", Performer);
            }
            if (!string.IsNullOrEmpty(Title))
            {
                appendCallback("title", Title);
            }

            base.AppendParameters(appendCallback);
        }
    }
}
