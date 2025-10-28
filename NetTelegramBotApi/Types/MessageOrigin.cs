namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object describes the origin of a message.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageorigin"/>
    /// </remarks>
    public class MessageOrigin
    {
        public MessageOriginType Type { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}
