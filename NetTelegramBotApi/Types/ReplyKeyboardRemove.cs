namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will remove the current custom keyboard
    /// and display the default letter-keyboard. By default, custom keyboards are displayed until a new keyboard is sent by a bot.
    /// An exception is made for one-time keyboards that are hidden immediately after the user presses a button
    /// (see ReplyKeyboardMarkup).
    /// Not supported in channels and for messages sent on behalf of a Telegram Business account.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#replykeyboardremove"/>
    /// </remarks>
    public class ReplyKeyboardRemove : ReplyMarkupBase
    {
        public required bool RemoveKeyboard { get; set; }

        public bool? Selective { get; set; }
    }
}
