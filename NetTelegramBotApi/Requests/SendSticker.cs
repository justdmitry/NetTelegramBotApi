using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send .webp stickers. On success, the sent Message is returned.
    /// </summary>
    public class SendSticker : SendFileRequestBase<Message>
    {
        public SendSticker(long chatId, FileToSend sticker)
            : base(chatId, "sendSticker", "sticker")
        {
            this.File = sticker;
        }

        public SendSticker(string channelName, FileToSend sticker)
            : base(channelName, "sendSticker", "sticker")
        {
            this.File = sticker;
        }

        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            base.AppendParameters(appendCallback);
        }
    }
}
