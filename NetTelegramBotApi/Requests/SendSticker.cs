using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send .webp stickers. On success, the sent Message is returned.
    /// </summary>
    public class SendSticker : SendFileRequestBase<Message>
    {
        public SendSticker(long chatId, FileToSend photo)
            : base("sendSticker", "sticker")
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
