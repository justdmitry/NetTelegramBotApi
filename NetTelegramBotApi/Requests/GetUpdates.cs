namespace NetTelegramBotApi.Requests
{
    /// <summary>
    /// Use this method to receive incoming updates using long polling (wiki).
    /// An Array of <see cref="Update"/> objects is returned.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#getupdates"/>
    /// </remarks>
    public class GetUpdates() : RequestBase<Update[]>("getUpdates")
    {
        public long? Offset { get; set; }

        public int? Limit { get; set; }

        public int? Timeout { get; set; }

        public string[]? AllowedUpdates { get; set; }
    }
}
