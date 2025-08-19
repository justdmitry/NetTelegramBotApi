namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get a list of administrators in a chat, which aren't bots.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getchatadministrators"/>
    /// </remarks>
    public class GetChatAdministrators() : RequestBase<ChatMember[]>("getChatAdministrators")
    {
        public required IntegerOrString ChatId { get; set; }
    }
}
