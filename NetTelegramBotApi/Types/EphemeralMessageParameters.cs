namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes the parameters of an ephemeral message to be sent.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#ephemeralmessageparameters"/>
    /// </remarks>
    public class EphemeralMessageParameters
    {
        public long? ReceiverUserId { get; set; }

        public string? CallbackQueryId { get; set; }

        public bool? ReplaceCallbackQueryMessage { get; set; }
    }
}
