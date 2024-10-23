namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    /// <remarks>
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will display unsupported message.
    /// </remarks>
    public class InlineKeyboardButton
    {
        /// <summary>
        /// Label text on the button.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. HTTP url to be opened when button is pressed.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Optional. Data to be sent in a callback query to the bot when button is pressed, 1-64 bytes.
        /// </summary>
        public string CallbackData { get; set; }

        /// <summary>
        /// Optional. Description of the Web App that will be launched when the user presses the button.
        /// </summary>
        /// <remarks>
        /// The Web App will be able to send an arbitrary message on behalf of the user using the method answerWebAppQuery.
        /// Available only in private chats between a user and the bot. Not supported for messages sent on behalf of a Telegram Business account.
        /// </remarks>
        public WebAppInfo WebApp { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats,
        /// open that chat and insert the bot‘s username and the specified inline query in the input field.
        /// Can be empty, in which case just the bot’s username will be inserted.
        /// </summary>
        /// <remarks>
        /// Note: This offers an easy way for users to start using your bot in inline mode when they are currently
        /// in a private chat with it. Especially useful when combined with switch_pm… actions – in this case the user
        /// will be automatically returned to the chat they switched from, skipping the chat selection screen.
        /// </remarks>
        public string SwitchInlineQuery { get; set; }

        /// <summary>
        /// Optional. If set, pressing the button will insert the bot‘s username and the specified inline query in the current chat's input field.
        /// Can be empty, in which case only the bot’s username will be inserted.
        /// This offers a quick way for the user to open your bot in inline mode
        /// in the same chat – good for selecting something from multiple options.
        /// </summary>
        public string SwitchInlineQueryCurrentChat { get; set; }

        /// <summary>
        /// Optional. Description of the game that will be launched when the user presses the button.
        /// NOTE: This type of button must always be the first button in the first row.
        /// </summary>
        public CallbackGame CallbackGame { get; set; }
    }
}
