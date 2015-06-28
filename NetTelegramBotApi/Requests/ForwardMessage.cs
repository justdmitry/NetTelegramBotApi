using System;
using System.Collections.Generic;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to forward messages of any kind. On success, the sent Message is returned.
    /// </summary>
    public class ForwardMessage : RequestBase<Message>
    {
        public ForwardMessage(long chatId, long fromChatId, long messageId) 
            : base("forwardMessage")
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

        public override HttpContent CreateHttpContent()
        {
            var values = new[]
            {
                new KeyValuePair<string, string>("chat_id", ChatId.ToString()),
                new KeyValuePair<string, string>("from_chat_id", FromChatId.ToString()),
                new KeyValuePair<string, string>("message_id", MessageId.ToString())
            };
            return new FormUrlEncodedContent(values);
        }
    }
}
