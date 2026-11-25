namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object contains information about the creation, token update, or owner update of a bot that is managed by the current bot.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#managedbotupdated"/>
    /// </remarks>
    public class ManagedBotUpdated
    {
        public required User User { get; set; }

        public required User Bot { get; set; }
    }
}
