using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using NetTelegramBotApi.Types;

namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to edit text and game messages sent by the bot or via the bot (for inline bots).
    /// On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.
    /// </summary>
    public class EditMessageText : RequestBase<Message>
    {
        public EditMessageText(long chatId, long messageId, string text)
            : base("editMessageText")
        {
            this.ChatId = chatId;
            this.MessageId = messageId;
            this.Text = text;
        }

        public EditMessageText(string channelName, long messageId, string text)
            : base("editMessageText")
        {
            this.ChannelName = channelName;
            this.MessageId = messageId;
            this.Text = text;
        }

        public EditMessageText(long inlineMessageId, string text)
            : base("editMessageText")
        {
            this.InlineMessageId = InlineMessageId;
            this.Text = text;
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
        /// New text of the message
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or
        /// inline URLs in your bot's message.
        /// </summary>
        public SendMessage.ParseModeEnum ParseMode { get; set; }

        /// <summary>
        /// Optional. Disables link previews for links in this message
        /// </summary>
        public bool? DisableWebPagePreview { get; set; }

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

            dic.Add("text", Text);

            if (ParseMode == SendMessage.ParseModeEnum.Markdown)
            {
                dic.Add("parse_mode", "Markdown");
            }

            if (ParseMode == SendMessage.ParseModeEnum.HTML)
            {
                dic.Add("parse_mode", "HTML");
            }

            if (DisableWebPagePreview.HasValue)
            {
                dic.Add("disable_web_page_preview", DisableWebPagePreview.Value.ToString());
            }

            if (ReplyMarkup != null)
            {
                dic.Add("reply_markup", JsonSerialize(ReplyMarkup));
            }

            return new FormUrlEncodedContent(dic);
        }
    }
}
