using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to unban a previously kicked user in a supergroup. The user will not return to the group automatically, but will be able to join via link, etc.
    /// The bot must be an administrator in the group for this to work. Returns True on success.
    /// </summary>
    public class UnbanChatMember : RequestBase<bool>
    {
        public UnbanChatMember(long chatId, long userId)
            : base("unbanChatMember")
        {
            this.ChatId = chatId;
            this.UserId = userId;
        }

        public UnbanChatMember(string channelName, long userId)
            : base("unbanChatMember")
        {
            this.ChannelName = channelName;
            this.UserId = userId;
        }

        /// <summary>
        /// Unique identifier for the target chat
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// Unique identifier of the target user
        /// </summary>
        public long UserId { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new Exception("Use ChatId or ChannelName, not both.");
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
