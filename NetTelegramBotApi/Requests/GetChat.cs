using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get up to date information about the chat
    /// (current name of the user for one-on-one conversations, current username of a user, group or channel, etc.).
    /// </summary>
    public class GetChat : RequestBase<Chat>
    {
        public GetChat(long chatId)
            : base("getChat")
        {
            this.ChatId = chatId;
        }

        public GetChat(string channelName)
            : base("getChat")
        {
            this.ChannelName = channelName;
        }

        /// <summary>
        /// Unique identifier for the target chat.
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Username of the target supergroup or channel (in the format @channelusername).
        /// </summary>
        public string ChannelName { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new InvalidOperationException("Use ChatId or ChannelName, not both.");
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

            return new FormUrlEncodedContent(dic);
        }
    }
}
