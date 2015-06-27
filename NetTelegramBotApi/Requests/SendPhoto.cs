using System;
using System.Collections.Generic;
using NetTelegramBotApi.Types;
using System.IO;
using System.Net.Http;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send photos. On success, the sent Message is returned.
    /// </summary>
    public class SendPhoto : RequestBase<Message>
    {
        public SendPhoto(long chatId, string photoId) 
            : base("sendPhoto")
        {
            this.ChatId = chatId;
            this.PhotoId = photoId;
        }

        public SendPhoto(long chatId, Stream photo, string photoFileName)
            : base("sendPhoto")
        {
            this.ChatId = chatId;
            this.PhotoStream = photo;
            this.PhotoStreamFileName = photoFileName;
        }

        /// <summary>
        /// Unique identifier for the message recipient — User or GroupChat id
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// Photo caption (may also be used when resending photos by file_id).
        /// </summary>
        public string Caption { get; set; }

        public string PhotoId { get; set; }

        public Stream PhotoStream { get; set; }

        public string PhotoStreamFileName { get; set; }

        /// <summary>
        /// Optional. If the message is a reply, ID of the original message
        /// </summary>
        public long? ReplyToMessageId { get; set; }

        /// <summary>
        /// Optional. Additional interface options. A JSON-serialized object for a custom reply keyboard, 
        /// instructions to hide keyboard or to force a reply from the user.
        /// </summary>
        public ReplyMarkupBase ReplyMarkup { get; set; }

        public override IDictionary<string, string> GetParameters()
        {
            var dic = new Dictionary<string, string>();

            dic.Add("chat_id", ChatId.ToString());
            dic.Add("caption", Caption);

            if (ReplyToMessageId.HasValue)
            {
                dic.Add("reply_to_message_id", ReplyToMessageId.Value.ToString());
            }
            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            return dic;
        }

        public override HttpContent CreateHttpContent()
        {
            var dic = new Dictionary<string, string>();

            dic.Add("chat_id", ChatId.ToString());
            dic.Add("caption", Caption);

            if (ReplyToMessageId.HasValue)
            {
                dic.Add("reply_to_message_id", ReplyToMessageId.Value.ToString());
            }
            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            if (!string.IsNullOrEmpty(PhotoId)) 
            {
                dic.Add("photo", PhotoId);
                return new FormUrlEncodedContent(dic);
            }

            var content = new MultipartFormDataContent();
            foreach(var pair in dic)
            {
                content.Add(new StringContent(pair.Value), pair.Key);
            }
            content.Add(new StreamContent(PhotoStream), "photo", PhotoStreamFileName);
            return content;
        }
    }
}
