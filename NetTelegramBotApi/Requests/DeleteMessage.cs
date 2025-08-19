namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to delete a message, including service messages.
    /// </summary>
    /// <remarks>
    /// There are some limitations, see <see href="https://core.telegram.org/bots/api#deletemessage"/>.
    /// </remarks>
    public class DeleteMessage() : RequestBase<bool>("deleteMessage")
    {
        public required IntegerOrString ChatId { get; set; }

        public required long MessageId { get; set; }
    }
}
