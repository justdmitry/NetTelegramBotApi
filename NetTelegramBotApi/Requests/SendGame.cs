using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send photos. On success, the sent Message is returned.
    /// <seealso cref="https://core.telegram.org/bots/api#games"/>
    /// </summary>
    public class SendGame : RequestBase<Message>
    {
        public SendGame(long chatId, string gameShortName)
            : base("sendGame")
        {
            this.ChatId = chatId;
            this.GameShortName = gameShortName;
        }

        public SendGame(string channelName, string gameShortName)
            : base("sendGame")
        {
            this.ChannelName = channelName;
            this.GameShortName = gameShortName;
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
        /// Unique identifier for the target message thread (topic) of the forum; for forum supergroups only.
        /// </summary>
        public long? MessageThreadId { get; set; }

        /// <summary>
        /// Short name of the game, serves as the unique identifier for the game. Set up your games via @Botfather.
        /// </summary>
        public string GameShortName { get; set; }

        /// <summary>
        /// Sends the message silently.
        /// iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Optional. If the message is a reply, ID of the original message.
        /// </summary>
        public long? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard,
        /// instructions to hide keyboard or to force a reply from the user.
        /// </summary>
        public ReplyMarkupBase ReplyMarkup { get; set; }

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

            if (MessageThreadId.HasValue)
            {
                dic.Add("message_thread_id", MessageThreadId.Value.ToString(CultureInfo.InvariantCulture));
            }

            dic.Add("game_short_name", GameShortName);

            if (DisableNotification.HasValue)
            {
                dic.Add("disable_notification", DisableNotification.Value.ToString());
            }

            if (ReplyToMessageId.HasValue)
            {
                dic.Add("reply_to_message_id", ReplyToMessageId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
