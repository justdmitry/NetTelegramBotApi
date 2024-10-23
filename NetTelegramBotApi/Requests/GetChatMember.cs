using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get information about a member of a chat. Returns a ChatMember object on success.
    /// </summary>
    public class GetChatMember : RequestBase<ChatMember>
    {
        public GetChatMember(long chatId, long userId)
            : base("getChatMember")
        {
            this.ChatId = chatId;
            this.UserId = userId;
        }

        public GetChatMember(string channelName, long userId)
            : base("getChatMember")
        {
            this.ChannelName = channelName;
            this.UserId = userId;
        }

        /// <summary>
        /// Unique identifier for the target chat.
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Username of the target channel (in the format @channelusername).
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// Unique identifier of the target user.
        /// </summary>
        public long UserId { get; set; }

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

            dic.Add("user_id", UserId.ToString(CultureInfo.InvariantCulture));

            return new FormUrlEncodedContent(dic);
        }
    }
}
