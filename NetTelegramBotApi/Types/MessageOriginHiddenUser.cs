namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// The message was originally sent by an unknown user.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageoriginhiddenuser"/>
    /// </remarks>
    public class MessageOriginHiddenUser : MessageOrigin
    {
        public string SenderUserName { get; set; } = default!;
    }
}
