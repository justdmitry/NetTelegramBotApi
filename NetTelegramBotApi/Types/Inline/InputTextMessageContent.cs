using System;
using static NetTelegramBotApi.Requests.SendMessage;

namespace NetTelegramBotApi.Types.Inline
{
    public class InputTextMessageContent : InputMessageContent
    {
        /// <summary>
        /// Text of the message to be sent, 1-4096 characters
        /// </summary>
        public string MessageText { get; set; }

        /// <summary>
        /// Optional. Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message.
        /// </summary>
        public ParseModeEnum ParseMode { get; set; }

        /// <summary>
        /// Optional. Disables link previews for links in the sent message
        /// </summary>
        public bool? DisableWebPagePreview { get; set; }
    }
}
