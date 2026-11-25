namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object describes an HTML widget.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#widget"/>
    /// </remarks>
    public class Widget
    {
        public string? Id { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public required string Html { get; set; }

        public string? PublicData { get; set; }

        public string? ChatData { get; set; }
    }
}
