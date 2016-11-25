using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an incoming callback query from a callback button in an inline keyboard. 
    /// If the button that originated the query was attached to a message sent by the bot, the field message will be presented. 
    /// If the button was attached to a message sent via the bot (in inline mode), the field inline_message_id will be presented.
    /// </summary>
    public class CallbackQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// Optional. Message with the callback button that originated the query. 
        /// Note that message content and message date will not be available if the message is too old
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Optional. Identifier of the message sent via the bot in inline mode, that originated the query
        /// </summary>
        public string InlineMessageId { get; set; }

        /// <summary>
        /// Data associated with the callback button. Be aware that a bad client can send arbitrary data in this field
        /// </summary>
        public string Data { get; set; }
    }
}
