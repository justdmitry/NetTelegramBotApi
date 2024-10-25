namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Contains information about the location of a Telegram Business account.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#businesslocation"/>
    /// </remarks>
    public class BusinessLocation
    {
        public string Address { get; set; } = string.Empty;

        public Location Location { get; set; } = default!;
    }
}
