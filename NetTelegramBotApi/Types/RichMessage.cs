namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Rich formatted message.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#richmessage"/>
    /// </remarks>
    public class RichMessage
    {
        public required RichBlock[] Blocks { get; set; }

        public bool? IsRtl { get; set; }
    }
}
