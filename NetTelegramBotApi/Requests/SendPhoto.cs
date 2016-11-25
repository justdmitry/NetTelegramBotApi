using System;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send photos. On success, the sent Message is returned.
    /// </summary>
    public class SendPhoto : SendFileRequestBase<Message>
    {
        public SendPhoto(long chatId, FileToSend photo) 
            : base(chatId, "sendPhoto", "photo")
        {
            this.File = photo;
        }
        public SendPhoto(string channelName, FileToSend photo)
            : base(channelName, "sendPhoto", "photo")
        {
            this.File = photo;
        }

        /// <summary>
        /// Photo caption (may also be used when resending photos by file_id).
        /// </summary>
        public string Caption { get; set; }

        protected override void AppendParameters(Action<string, string> appendCallback)
        {
            if (!string.IsNullOrEmpty(Caption))
            {
                appendCallback("caption", Caption);
            }
            base.AppendParameters(appendCallback);
        }
    }
}
