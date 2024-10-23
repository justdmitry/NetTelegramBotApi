using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to set the score of the specified user in a game.
    /// On success, if the message was sent by the bot, returns the edited Message, otherwise returns True.
    /// Returns an error, if the new score is not greater than the user's current score in the chat.
    /// </summary>
    public class SetGameScore : RequestBase<Message>
    {
        public SetGameScore(long userId, long score)
            : base("setGameScore")
        {
            this.UserId = userId;
            this.Score = score;
        }

        /// <summary>
        /// User identifier.
        /// </summary>
        public long UserId { get; protected set; }

        /// <summary>
        /// New score, must be positive.
        /// </summary>
        public long Score { get; protected set; }

        /// <summary>
        /// Pass True, if the high score is allowed to decrease. This can be useful when fixing mistakes or banning cheaters.
        /// </summary>
        public bool Force { get; set; }

        /// <summary>
        /// Pass True, if the game message should not be automatically edited to include the current scoreboard.
        /// </summary>
        public bool DisableEditMessage { get; set; }

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
            dic.Add("score", Score.ToString(CultureInfo.InvariantCulture));

            dic.Add("force", Force.ToString());

            dic.Add("disable_edit_message", DisableEditMessage.ToString());

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
