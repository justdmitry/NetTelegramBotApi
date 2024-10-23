using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get the number of members in a chat. Returns Int on success.
    /// </summary>
    public class GetChatMembersCount : RequestBase<int>
    {
        public GetChatMembersCount(long chatId)
            : base("getChatMembersCount")
        {
            this.ChatId = chatId;
        }

        public GetChatMembersCount(string channelName)
            : base("getChatMembersCount")
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
