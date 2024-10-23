using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to kick a user from a group or a supergroup.
    /// </summary>
    /// <remarks>
    /// Note: This will method only work if the ‘All Members Are Admins’ setting is off in the target group.
    /// Otherwise members may only be removed by the group's creator or by the member that added them.
    ///
    /// In the case of supergroups, the user will not be able to return to the group on their own using invite links, etc., unless unbanned first.
    /// The bot must be an administrator in the group for this to work.
    /// Returns True on success.
    /// </remarks>
    public class KickChatMember : RequestBase<bool>
    {
        public KickChatMember(long chatId, long userId)
            : base("kickChatMember")
        {
            this.ChatId = chatId;
            this.UserId = userId;
        }

        public KickChatMember(string channelName, long userId)
            : base("kickChatMember")
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
