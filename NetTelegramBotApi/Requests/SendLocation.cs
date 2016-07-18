using System;
using System.Collections.Generic;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send text messages. On success, the sent Message is returned.
    /// </summary>
    public class SendLocation : RequestBase<Message>
    {
        public SendLocation(long chatId, float latitude, float longitude)
            : base("sendLocation")
        {
            this.ChatId = chatId;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
        public SendLocation(string channelName, float latitude, float longitude)
            : base("sendLocation")
        {
            this.ChannelName = channelName;
            this.Latitude = latitude;
            this.Longitude = longitude;
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
        /// Latitude of location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Longitude of location
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        /// Sends the message silently. 
        /// iOS users will not receive a notification, Android users will receive a notification with no sound.
        /// </summary>
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// Optional. If the message is a reply, ID of the original message
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
                dic.Add("chat_id", ChatId.Value.ToString());
            }
            if (!string.IsNullOrEmpty(ChannelName))
            {
                dic.Add("chat_id", ChannelName);
            }
            dic.Add("latitude", Latitude.ToString());
            dic.Add("longitude", Longitude.ToString());

            if (DisableNotification.HasValue)
            {
                dic.Add("disable_notification", DisableNotification.Value.ToString());
            }
            if (ReplyToMessageId.HasValue)
            {
                dic.Add("reply_to_message_id", ReplyToMessageId.Value.ToString());
            }
            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
