namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes the opening hours of a business.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#businessopeninghours"/>
    /// </remarks>
    public class BusinessOpeningHours
    {
        public string TimeZoneName { get; set; } = string.Empty;

        public BusinessOpeningHoursInterval[] OpeningHours { get; set; } = [];
    }
}
