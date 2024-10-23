using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get a list of administrators in a chat.
    /// On success, returns an Array of ChatMember objects that contains information about all chat administrators except other bots.
    /// If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.
    /// </summary>
    public class GetChatAdministrators : RequestBase<ChatMember[]>
    {
        public GetChatAdministrators(long chatId)
            : base("getChatAdministrators")
        {
            this.ChatId = chatId;
        }

        public GetChatAdministrators(string channelName)
            : base("getChatAdministrators")
        {
            this.ChannelName = channelName;
        }

        /// <summary>
        /// Unique identifier for the target chat
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Username of the target supergroup or channel (in the format @channelusername)
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
