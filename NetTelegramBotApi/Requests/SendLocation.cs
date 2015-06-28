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
            this.Longitude = Longitude;
        }

        /// <summary>
        /// Unique identifier for the message recipient — User or GroupChat id
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// Latitude of location
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        /// Longitude of location
        /// </summary>
        public float Longitude { get; set; }

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
            var dic = new Dictionary<string, string>();

            dic.Add("chat_id", ChatId.ToString());
            dic.Add("latitude", Latitude.ToString());
            dic.Add("longitude", Longitude.ToString());

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
