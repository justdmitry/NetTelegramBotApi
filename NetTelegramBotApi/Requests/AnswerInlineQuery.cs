using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types.Inline;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to send answers to callback queries sent from inline keyboards.
    /// The answer will be displayed to the user as a notification at the top of the chat screen or as an alert.
    /// On success, True is returned.
    /// </summary>
    public class AnswerInlineQuery : RequestBase<bool>
    {
        public AnswerInlineQuery(string inlineQueryId)
            : base("answerInlineQuery")
        {
            this.InlineQueryId = inlineQueryId;
        }

        /// <summary>
        /// Unique identifier for the answered query
        /// </summary>
        public string InlineQueryId { get; protected set; }

        /// <summary>
        /// A JSON-serialized array of results for the inline query
        /// </summary>
        public InlineQueryResult[] Results { get; set; }

        /// <summary>
        /// Optional. The maximum amount of time in seconds that the result of the inline query may be cached on the server.
        /// Defaults to 300.
        /// </summary>
        public int? CacheTime { get; set; }

        /// <summary>
        /// Optional. Pass True, if results may be cached on the server side only for the user that sent the query.
        /// By default, results may be returned to any user who sends the same query
        /// </summary>
        public bool IsPersonal { get; set; }

        /// <summary>
        /// Optional. Pass the offset that a client should send in the next query with the same text to receive more results.
        /// Pass an empty string if there are no more results or if you don‘t support pagination.
        /// Offset length can’t exceed 64 bytes.
        /// </summary>
        public string NextOffset { get; set; }

        /// <summary>
        /// Optional. If passed, clients will display a button with specified text that switches the user to a private chat
        /// with the bot and sends the bot a start message with the parameter switch_pm_parameter
        /// </summary>
        public string SwitchPmText { get; set; }

        /// <summary>
        /// Optional . Deep-linking parameter for the /start message sent to the bot when user presses the switch button.
        /// 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed.
        /// </summary>
        public string SwitchPmParameter { get; set; }

        public override HttpContent CreateHttpContent()
        {
            var dic = new Dictionary<string, string>();
            dic.Add("inline_query_id", InlineQueryId);

            dic.Add("results", JsonSerialize(Results));

            if (CacheTime.HasValue)
            {
                dic.Add("cache_time", CacheTime.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (IsPersonal)
            {
                dic.Add("is_personal", IsPersonal.ToString());
            }

            if (NextOffset != null)
            {
                dic.Add("next_offset", NextOffset);
            }

            if (!string.IsNullOrEmpty(SwitchPmText))
            {
                dic.Add("switch_pm_text", SwitchPmText);
            }

            if (!string.IsNullOrEmpty(SwitchPmParameter))
            {
                dic.Add("switch_pm_parameter", SwitchPmParameter);
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
