namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes the price of a suggested post.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#suggestedpostprice"/>
    /// </remarks>
    public class SuggestedPostPrice
    {
        public required string Currency { get; set; }

        public required long Amount { get; set; }
    }
}
