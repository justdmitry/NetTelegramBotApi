namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes an interval of time during which a business is open.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#businessopeninghoursinterval"/>
    /// </remarks>
    public class BusinessOpeningHoursInterval
    {
        public int OpeningMinute { get; set; }

        public int ClosingMinute { get; set; }
    }
}
