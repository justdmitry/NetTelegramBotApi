namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Contains information about a suggested post.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#suggestedpostinfo"/>
    /// </remarks>
    public class SuggestedPostInfo
    {
        public required string State { get; set; }

        public SuggestedPostPrice? Price { get; set; }

        public DateTimeOffset? SendDate { get; set; }
    }
}
