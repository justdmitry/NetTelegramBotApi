namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one size of a photo or a file / sticker thumbnail.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#photosize"/>
    /// </remarks>
    public class PhotoSize
    {
        public string FileId { get; set; } = string.Empty;

        public string FileUniqueId { get; set; } = string.Empty;

        public int Width { get; set; }

        public int Height { get; set; }

        public int? FileSize { get; set; }
    }
}
