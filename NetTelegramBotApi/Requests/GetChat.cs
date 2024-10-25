namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get up-to-date information about the chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getchat"/>
    /// </remarks>
    public class GetChat() : RequestBase<ChatFullInfo>("getChat")
    {
        public required IntegerOrString ChatId { get; set; }
    }
}
