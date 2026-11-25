namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes a service message about the chat owner leaving the chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatownerleft"/>
    /// </remarks>
    public class ChatOwnerLeft
    {
        public User? NewOwner { get; set; }
    }
}
