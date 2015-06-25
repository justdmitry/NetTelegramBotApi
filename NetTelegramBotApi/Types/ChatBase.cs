using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Base class for <see cref="User"/> and <see cref="GroupChat"/>
    /// </summary>
    public abstract class ChatBase
    {
        /// <summary>
        /// Unique identifier for this user, or bot, or group chat
        /// </summary>
        public long Id { get; set; }
    }
}
