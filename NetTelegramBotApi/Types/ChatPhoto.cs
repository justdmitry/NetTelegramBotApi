namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a chat photo.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#chatphoto"/>
    /// </remarks>
    public class ChatPhoto
    {
        public string SmallFileId { get; set; } = string.Empty;

        public string SmallFileUniqueId { get; set; } = string.Empty;

        public string BigFileId { get; set; } = string.Empty;

        public string BigFileUniqueId { get; set; } = string.Empty;
    }
}
