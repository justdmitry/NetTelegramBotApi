namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to delete an ephemeral message.
    /// Note that it is not guaranteed that the user will receive the message deletion event, especially if they are offline.
    /// Returns True on success.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#deleteephemeralmessage"/>.
    /// </remarks>
    public class DeleteEphemeralMessage() : RequestBase<bool>("deleteEphemeralMessage")
    {
        public required IntegerOrString ChatId { get; set; }

        public required long ReceiverUserId { get; set; }

        public required long EphemeralMessageId { get; set; }
    }
}
