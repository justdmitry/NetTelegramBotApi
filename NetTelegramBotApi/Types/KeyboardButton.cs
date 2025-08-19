namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one button of the reply keyboard. At most one of the optional fields must be used to specify type of the button.
    /// For simple text buttons, String can be used instead of this object to specify the button text.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#keyboardbutton"/>
    /// </remarks>
    public class KeyboardButton
    {
        public required string Text { get; set; }

        public KeyboardButtonRequestUsers? RequestUsers { get; set; }

        // TODO: Implement
        public object? RequestChat { get; set; }

        public bool? RequestContact { get; set; }

        public bool? RequestLocation { get; set; }

        // TODO: Implement
        public object? RequestPoll { get; set; }

        public WebAppInfo? WebApp { get; set; }
    }
}
