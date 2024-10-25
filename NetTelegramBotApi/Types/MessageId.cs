namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a unique message identifier.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#messageid"/>
    /// </remarks>
    public class MessageId
    {
        [JsonPropertyName("message_id")]
        public long Id { get; set; }
    }
}
