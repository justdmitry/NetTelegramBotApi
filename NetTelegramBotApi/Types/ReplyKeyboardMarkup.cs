namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a custom keyboard with reply options (see Introduction to bots for details and examples).
    /// Not supported in channels and for messages sent on behalf of a Telegram Business account.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#replykeyboardmarkup"/>
    /// </remarks>
    public class ReplyKeyboardMarkup : ReplyMarkupBase
    {
        public required KeyboardButton[][] Keyboard { get; set; }

        public bool? IsPersistent { get; set; }

        public bool? ResizeKeyboard { get; set; }

        public bool? OneTimeKeyboard { get; set; }

        public string? InputFieldPlaceholder { get; set; }

        public bool? Selective { get; set; }
    }
}
