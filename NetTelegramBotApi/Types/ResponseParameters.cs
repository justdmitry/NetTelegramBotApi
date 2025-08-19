namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes why a request was unsuccessful.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#responseparameters"/>
    /// </remarks>
    public class ResponseParameters
    {
        public long? MigrateToChatId { get; set; }

        public long? RetryAfter { get; set; }
    }
}
