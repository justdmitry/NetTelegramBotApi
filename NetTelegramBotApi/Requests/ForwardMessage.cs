using System;
using System.Collections.Generic;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to forward messages of any kind. On success, the sent Message is returned.
    /// </summary>
    public class ForwardMessage : RequestBase<Message>
    {
        public ForwardMessage(long chatId, long fromChatId, long messageId) : base("forwardMessage")
        {
            this.ChatId = chatId;
            this.FromChatId = fromChatId;
            this.MessageId = messageId;
        }

        /// <summary>
        /// Unique identifier for the message recipient — User or GroupChat id
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// Unique identifier for the chat where the original message was sent — User or GroupChat id
        /// </summary>
        public long FromChatId { get; set; }

        /// <summary>
        /// Unique message identifier
        /// </summary>
        public long MessageId { get; set; }

        public override IDictionary<string, string> GetParameters()
        {
            var dic = new Dictionary<string, string>();

            dic.Add("chat_id", ChatId.ToString());
            dic.Add("from_chat_id", FromChatId.ToString());
            dic.Add("message_id", MessageId.ToString());

            return dic;
        }
    }
}
