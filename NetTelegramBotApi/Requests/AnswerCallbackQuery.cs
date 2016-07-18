using System;
using System.Collections.Generic;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send answers to callback queries sent from inline keyboards. 
    /// The answer will be displayed to the user as a notification at the top of the chat screen or as an alert. 
    /// On success, True is returned.
    /// </summary>
    public class AnswerCallbackQuery : RequestBase<bool>
    {
        public AnswerCallbackQuery(string callbackQueryId)
            : base("answerCallbackQuery")
        {
            this.CallbackQueryId = callbackQueryId;
        }

        /// <summary>
        /// Unique identifier for the query to be answered
        /// </summary>
        public string CallbackQueryId { get; protected set; }

        /// <summary>
        /// Optional. Text of the notification. If not specified, nothing will be shown to the user
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. If true, an alert will be shown by the client instead of a notification at the top of the chat screen. 
        /// Defaults to false.
        /// </summary>
        public bool? ShowAlert { get; set; }

        public override HttpContent CreateHttpContent()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("callback_query_id", CallbackQueryId);
            if (!string.IsNullOrEmpty(Text))
            {
                dic.Add("text", Text);
            }
            if (ShowAlert.HasValue)
            {
                dic.Add("show_alert", ShowAlert.Value.ToString());
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
