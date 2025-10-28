namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// The message was originally sent by a known user.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageoriginuser"/>
    /// </remarks>
    public class MessageOriginUser : MessageOrigin
    {
        public User SenderUser { get; set; } = default!;
    }
}
