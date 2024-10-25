namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an inline button that switches the current user to inline mode in a chosen chat, with an optional default inline query.
    /// </summary>
    /// <remarks>
    /// <seealso href="https://core.telegram.org/bots/api#switchinlinequerychosenchat"/>
    /// </remarks>
    public class SwitchInlineQueryChosenChat
    {
        public string? Query { get; set; }

        public bool? AllowUserChats { get; set; }

        public bool? AllowBotChats { get; set; }

        public bool? AllowGroupChats { get; set; }

        public bool? AllowChannelChats { get; set; }
    }
}
