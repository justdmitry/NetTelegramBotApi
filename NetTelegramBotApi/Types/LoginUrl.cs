namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a parameter of the inline keyboard button used to automatically authorize a user.
    /// Serves as a great replacement for the Telegram Login Widget when the user is coming from Telegram.
    /// All the user needs to do is tap/click a button and confirm that they want to log in.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#loginurl"/>
    /// </remarks>
    public class LoginUrl
    {
        public required string Url { get; set; }

        public string? ForwardText { get; set; }

        public string? BotUsername { get; set; }

        public bool? RequestWriteAccess { get; set; }
    }
}
