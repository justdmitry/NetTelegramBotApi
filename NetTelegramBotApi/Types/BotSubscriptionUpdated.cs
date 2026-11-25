namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object contains information about changes to a user payment subscription toward the current bot.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#botsubscriptionupdated"/>
    /// </remarks>
    public class BotSubscriptionUpdated
    {
        public required User User { get; set; }

        public required string InvoicePayload { get; set; }

        public required string State { get; set; }
    }
}
