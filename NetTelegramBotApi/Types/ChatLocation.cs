namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Represents a location to which a chat is connected.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatlocation"/>
    /// </remarks>
    public class ChatLocation
    {
        public Location Location { get; set; } = default!;

        public string Address { get; set; } = string.Empty;
    }
}
