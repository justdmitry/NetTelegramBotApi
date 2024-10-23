namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    public class Update
    {
        /// <summary>
        /// The update‘s unique identifier. Update identifiers start from a certain positive number and increase sequentially.
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates
        ///   or to restore the correct update sequence, should they get out of order.
        /// </summary>
        public long UpdateId { get; set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        public Message Message { get; set; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        public Message EditedMessage { get; set; }

        /// <summary>
        /// Optional. New incoming channel post of any kind — text, photo, sticker, etc.
        /// </summary>
        public Message ChannelPost { get; set; }

        /// <summary>
        /// Optional. New version of a channel post that is known to the bot and was edited
        /// </summary>
        public Message EditedChannelPost { get; set; }

        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        public InlineQuery InlineQuery { get; set; }

        /// <summary>
        /// Optional. The result of an inline query that was chosen by a user and sent to their chat partner.
        /// </summary>
        public ChosenInlineResult ChosenInlineResult { get; set; }

        /// <summary>
        /// Optional. New incoming callback query
        /// </summary>
        public CallbackQuery CallbackQuery { get; set; }
    }
}
