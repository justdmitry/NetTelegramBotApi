namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to delete multiple messages simultaneously.
    /// If some of the specified messages can't be found, they are skipped.
    /// </summary>
    /// <remarks>
    /// There are some limitations, see <see href="https://core.telegram.org/bots/api#deletemessages"/>.
    /// </remarks>
    public class DeleteMessages() : RequestBase<bool>("deleteMessages")
    {
        public required IntegerOrString ChatId { get; set; }

        public required long[] MessageIds { get; set; }
    }
}
