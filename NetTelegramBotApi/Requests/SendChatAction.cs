using System;
using System.Collections.Generic;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method when you need to tell the user that something is happening on the bot's side. 
    /// The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status). 
    /// </summary>
    /// <remarks>
    /// We only recommend using this method when a response from the bot will take a <b>noticeable</b> amount of time to arrive.
    /// </remarks>
    public class SendChatAction : RequestBase<object>
    {
        public SendChatAction(long chatId, string action) 
            : base("sendChatAction")
        {
            this.ChatId = chatId;
            this.Action = action;
        }

        /// <summary>
        /// Unique identifier for the message recipient — User or GroupChat id
        /// </summary>
        public long ChatId { get; set; }

        /// <summary>
        /// Type of action to broadcast. 
        /// Choose one, depending on what the user is about to receive: 
        ///   typing for text messages, 
        ///   upload_photo for photos, 
        ///   record_video or upload_video for videos, 
        ///   record_audio or upload_audio for audio files, 
        ///   upload_document for general files, 
        ///   find_location for location data.
        /// </summary>
        public string Action { get; set; }

        public override HttpContent CreateHttpContent()
        {
            var values = new[]
            {
                new KeyValuePair<string, string>("chat_id", ChatId.ToString()),
                new KeyValuePair<string, string>("action", Action)
            };

            return new FormUrlEncodedContent(values);
        }
    }
}
