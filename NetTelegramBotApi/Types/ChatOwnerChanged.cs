namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes a service message about an ownership change in the chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatownerchanged"/>
    /// </remarks>
    public class ChatOwnerChanged
    {
        public User? NewOwner { get; set; }
    }
}
