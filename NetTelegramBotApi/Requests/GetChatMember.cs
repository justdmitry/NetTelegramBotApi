namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to get information about a member of a chat.
    /// The method is only guaranteed to work for other users if the bot is an administrator in the chat.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getchatmember"/>
    /// </remarks>
    public class GetChatMember() : RequestBase<ChatMember>("getChatMember")
    {
        public required IntegerOrString ChatId { get; set; }

        public required long UserId { get; set; }
    }
}
