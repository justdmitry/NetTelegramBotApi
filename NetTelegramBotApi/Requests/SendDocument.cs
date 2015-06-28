using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send general files. On success, the sent Message is returned. 
    /// Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
    /// </summary>
    public class SendDocument : SendFileRequestBase<Message>
    {
        public SendDocument(long chatId, FileToSend photo) 
            : base("sendDocument", "document")
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
