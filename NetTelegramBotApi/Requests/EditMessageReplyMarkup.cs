using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to edit captions of messages sent by the bot or via the bot (for inline bots).
    /// On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.
    /// </summary>
    public class EditMessageReplyMarkup : RequestBase<Message>
    {
        public EditMessageReplyMarkup(long chatId, long messageId, InlineKeyboardMarkup replyMarkup)
            : base("editMessageReplyMarkup")
        {
            this.ChatId = chatId;
            this.MessageId = messageId;
            this.ReplyMarkup = replyMarkup;
        }

        public EditMessageReplyMarkup(string channelName, long messageId, InlineKeyboardMarkup replyMarkup)
            : base("editMessageReplyMarkup")
        {
            this.ChannelName = channelName;
            this.MessageId = messageId;
            this.ReplyMarkup = replyMarkup;
        }

        public EditMessageReplyMarkup(long inlineMessageId, InlineKeyboardMarkup replyMarkup)
            : base("editMessageReplyMarkup")
        {
            this.InlineMessageId = InlineMessageId;
            this.ReplyMarkup = replyMarkup;
        }

        /// <summary>
        /// Optional. Required if inline_message_id is not specified. Unique identifier for the target chat.
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Optional. Required if inline_message_id is not specified. Username of the target channel.
        /// </summary>
        public string ChannelName { get; protected set; }

        /// <summary>
        /// Optional. Required if inline_message_id is not specified. Identifier of the sent message.
        /// </summary>
        public long? MessageId { get; protected set; }

        /// <summary>
        /// Optional. Required if chat_id and message_id are not specified. Identifier of the inline message.
        /// </summary>
        public long? InlineMessageId { get; protected set; }

        /// <summary>
        /// Optional. A JSON-serialized object for an inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new InvalidOperationException("Use ChatId or ChannelName, not both.");
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

            if (MessageId.HasValue)
            {
                dic.Add("message_id", MessageId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (InlineMessageId.HasValue)
            {
                dic.Add("inline_message_id", InlineMessageId.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
