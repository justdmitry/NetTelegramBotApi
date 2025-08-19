namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Describes the options used for link preview generation.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#linkpreviewoptions"/>
    /// </remarks>
    public class LinkPreviewOptions
    {
        public bool? IsDisabled { get; set; }

        public string? Url { get; set; }

        public bool? PreferSmallMedia { get; set; }

        public bool? PreferLargeMedia { get; set; }

        public bool? ShowAboveText { get; set; }
    }
}
