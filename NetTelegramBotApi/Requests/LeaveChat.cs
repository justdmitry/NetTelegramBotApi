using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method for your bot to leave a group, supergroup or channel. Returns True on success.
    /// </summary>
    public class LeaveChat : RequestBase<bool>
    {
        public LeaveChat(long chatId)
            : base("leaveChat")
        {
            this.ChatId = chatId;
        }

        public LeaveChat(string channelName)
            : base("leaveChat")
        {
            this.ChannelName = channelName;
        }

        /// <summary>
        /// Unique identifier for the target chat
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Username of the target channel (in the format @channelusername)
        /// </summary>
        public string ChannelName { get; set; }

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

            return new FormUrlEncodedContent(dic);
        }
    }
}
