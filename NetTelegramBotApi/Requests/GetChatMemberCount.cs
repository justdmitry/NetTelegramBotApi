namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get the number of members in a chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getchatmembercount"/>
    /// </remarks>
    public class GetChatMemberCount() : RequestBase<int>("getChatMemberCount")
    {
        public required IntegerOrString ChatId { get; set; }
    }
}
