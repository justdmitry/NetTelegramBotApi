namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Contains information about the start page settings of a Telegram Business account.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#businessintro"/>
    /// </remarks>
    public class BusinessIntro
    {
        public string? Title { get; set; }

        public string? Message { get; set; }

        public Sticker? Sticker{ get; set; }
    }
}
