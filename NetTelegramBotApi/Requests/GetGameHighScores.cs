using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get data for high score tables.
    /// Will return the score of the specified user and several of his neighbors in a game.
    /// On success, returns an Array of GameHighScore objects.
    /// </summary>
    /// <remarks>
    /// This method will currently return scores for the target user, plus two of his closest neighbors on each side.
    /// Will also return the top three users if the user and his neighbors are not among them.
    /// Please note that this behavior is subject to change.
    /// </remarks>
    public class GetGameHighScores : RequestBase<GameHighScore[]>
    {
        public GetGameHighScores(long userId)
            : base("getGameHighScores")
        {
            this.UserId = userId;
        }

        /// <summary>
        /// Target user id.
        /// </summary>
        public long UserId { get; protected set; }

        /// <summary>
        /// Required if inline_message_id is not specified. Unique identifier for the target chat.
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Required if inline_message_id is not specified. Unique identifier for the target chat.
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// Required if inline_message_id is not specified. Identifier of the sent message.
        /// </summary>
        public long? MessageId { get; set; }

        /// <summary>
        /// Required if chat_id and message_id are not specified. Identifier of the inline message.
        /// </summary>
        public string InlineMessageId { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new InvalidOperationException("Use ChatId or ChannelName, not both.");
            }

            var dic = new Dictionary<string, string>();

            dic.Add("user_id", UserId.ToString(CultureInfo.InvariantCulture));

            if (ChatId.HasValue)
            {
                dic.Add("chat_id", ChatId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(ChannelName))
            {
                dic.Add("chat_id", ChannelName);
            }

            if (MessageId.HasValue)
            {
                dic.Add("message_id", MessageId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (!string.IsNullOrEmpty(InlineMessageId))
            {
                dic.Add("inline_message_id", InlineMessageId);
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
