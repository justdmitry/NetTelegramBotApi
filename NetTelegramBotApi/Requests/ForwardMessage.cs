using System;
using System.Collections.Generic;
using System.Globalization;
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

        public ForwardMessage(long chatId, string fromChannelName, long messageId)
            : base("forwardMessage")
        {
            this.ChatId = chatId;
            this.FromChannelName = fromChannelName;
            this.MessageId = messageId;
        }

        public ForwardMessage(string channelName, long fromChatId, long messageId)
            : base("forwardMessage")
        {
            this.ChannelName = channelName;
            this.FromChatId = fromChatId;
            this.MessageId = messageId;
        }

        public ForwardMessage(string channelName, string fromChannelName, long messageId)
            : base("forwardMessage")
        {
            this.ChannelName = channelName;
            this.FromChannelName = fromChannelName;
            this.MessageId = messageId;
        }

        /// <summary>
        /// Unique identifier for the target chat
        /// </summary>
        public long? ChatId { get; set; }

        /// <summary>
        /// Unique identifier for target channel (in the format @channelusername)
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only
        /// </summary>
        public long? MessageThreadId { get; set; }

        /// <summary>
        /// Unique identifier for the chat where the original message was sent — User or GroupChat id
        /// </summary>
        public long? FromChatId { get; set; }

        /// <summary>
        /// Unique identifier for the chat where the original message was sent - channel username in the format @channelusername)
        /// </summary>
        public string FromChannelName { get; set; }

        /// <summary>
        /// Sends the message silently.
        /// iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Unique message identifier
        /// </summary>
        public long MessageId { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new Exception("Use ChatId or ChannelName, not both.");
            }

            if (FromChatId.HasValue && !string.IsNullOrEmpty(FromChannelName))
            {
                throw new Exception("Use FromChatId or FromChannelName, not both.");
            }

            var dic = new Dictionary<string, string>();

            if (ChatId.HasValue)
            {
                dic.Add("chat_id", ChatId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(ChannelName))
            {
                dic.Add("chat_id", ChannelName);
            }

            if (MessageThreadId.HasValue)
            {
                dic.Add("message_thread_id", MessageThreadId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (FromChatId.HasValue)
            {
                dic.Add("from_chat_id", FromChatId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(FromChannelName))
            {
                dic.Add("from_chat_id", FromChannelName);
            }

            if (DisableNotification.HasValue)
            {
                dic.Add("disable_notification", DisableNotification.Value.ToString());
            }

            dic.Add("message_id", MessageId.ToString(CultureInfo.InvariantCulture));

            return new FormUrlEncodedContent(dic);
        }
    }
}
