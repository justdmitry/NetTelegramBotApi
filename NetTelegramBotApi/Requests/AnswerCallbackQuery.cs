using System;
using System.Collections.Generic;
using System.Net.Http;

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

        /// <summary>
        /// Optional. URL that will be opened by the user's client.
        /// If you have created a Game and accepted the conditions via @Botfather,
        /// specify the URL that opens your game – note that this will only work if the query comes from a callback_game button.
        /// Otherwise, you may use links like telegram.me/your_bot?start=XXXX that open your bot with a parameter.
        /// </summary>
        public string Url { get; set; }

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

            if (!string.IsNullOrEmpty(Url))
            {
                dic.Add("url", Url);
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
