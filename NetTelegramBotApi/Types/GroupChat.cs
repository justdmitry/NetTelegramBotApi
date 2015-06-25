using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a group chat.
    /// </summary>
    public class GroupChat : ChatBase
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string Title { get; set; }
    }
}
