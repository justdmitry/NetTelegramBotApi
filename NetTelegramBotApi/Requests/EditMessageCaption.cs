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
    public class EditMessageCaption : RequestBase<Message>
    {
        public EditMessageCaption(long chatId, long messageId, string caption)
            : base("editMessageCaption")
        {
            this.ChatId = chatId;
            this.MessageId = messageId;
            this.Caption = caption;
        }

        public EditMessageCaption(string channelName, long messageId, string caption)
            : base("editMessageCaption")
        {
            this.ChannelName = channelName;
            this.MessageId = messageId;
            this.Caption = caption;
        }

        public EditMessageCaption(long inlineMessageId, string caption)
            : base("editMessageCaption")
        {
            this.InlineMessageId = InlineMessageId;
            this.Caption = caption;
        }

        /// <summary>
        /// Optional. Required if inline_message_id is not specified. Unique identifier for the target chat
        /// </summary>
        public long? ChatId { get; protected set; }

        /// <summary>
        /// Optional. Required if inline_message_id is not specified. Username of the target channel
        /// </summary>
        public string ChannelName { get; protected set; }

        /// <summary>
        /// Optional. Required if inline_message_id is not specified. Identifier of the sent message
        /// </summary>
        public long? MessageId { get; protected set; }

        /// <summary>
        /// Optional. Required if chat_id and message_id are not specified. Identifier of the inline message
        /// </summary>
        public long? InlineMessageId { get; protected set; }

        /// <summary>
        /// Optional. New caption of the message
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Optional. A JSON-serialized object for an inline keyboard.
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }

        public override HttpContent CreateHttpContent()
        {
            if (ChatId.HasValue && !string.IsNullOrEmpty(ChannelName))
            {
                throw new Exception("Use ChatId or ChannelName, not both.");
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

            dic.Add("caption", Caption);

            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
