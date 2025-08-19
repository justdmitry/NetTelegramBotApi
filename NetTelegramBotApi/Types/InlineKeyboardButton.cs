namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#inlinekeyboardbutton"/>
    /// </remarks>
    public class InlineKeyboardButton
    {
        public required string Text { get; set; }

        public string? Url { get; set; }

        public string? CallbackData { get; set; }

        public WebAppInfo? WebApp { get; set; }

        public LoginUrl? LoginUrl { get; set; }

        public string? SwitchInlineQuery { get; set; }

        public string? SwitchInlineQueryCurrentChat { get; set; }

        public SwitchInlineQueryChosenChat? SwitchInlineQueryChosenChat { get; set; }

        public CallbackGame? CallbackGame { get; set; }

        public bool? Pay { get; set; }
    }
}
