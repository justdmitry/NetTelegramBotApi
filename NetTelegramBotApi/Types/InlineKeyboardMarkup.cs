namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to.
    /// </summary>
    /// <remarks>
    /// Warning: Inline keyboards are currently being tested and are not available in channels yet. For now, feel free to use them in one-on-one chats or groups.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will display unsupported message.
    /// </remarks>
    public class InlineKeyboardMarkup : ReplyMarkupBase
    {
        /// <summary>
        /// Array of button rows, each represented by an Array of InlineKeyboardButton objects.
        /// </summary>
        public InlineKeyboardButton[][] InlineKeyboard { get; set; }
    }
}
