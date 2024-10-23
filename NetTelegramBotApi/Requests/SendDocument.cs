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
        public SendDocument(long chatId, FileToSend document)
            : base(chatId, "sendDocument", "document")
        {
            this.File = document;
        }
        public SendDocument(string channelName, FileToSend document)
            : base(channelName, "sendDocument", "document")
        {
            this.File = document;
        }

        /// <summary>
        /// Document caption (may also be used when resending documents by file_id), 0-200 characters
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
