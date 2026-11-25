namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Contains parameters of a post that is being suggested by the bot.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#suggestedpostparameters"/>
    /// </remarks>
    public class SuggestedPostParameters
    {
        public SuggestedPostPrice? Price { get; set; }

        public DateTimeOffset? SendDate { get; set; }
    }
}
