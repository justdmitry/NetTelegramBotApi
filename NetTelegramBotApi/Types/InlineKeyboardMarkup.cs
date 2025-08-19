namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an inline keyboard that appears right next to the message it belongs to.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inlinekeyboardmarkup"/>
    /// </remarks>
    public class InlineKeyboardMarkup : ReplyMarkupBase
    {
        public required InlineKeyboardButton[][] InlineKeyboard { get; set; }
    }
}
