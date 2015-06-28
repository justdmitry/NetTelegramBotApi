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
        
        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            base.AppendParameters(appendCallback);
        }
    }
}
