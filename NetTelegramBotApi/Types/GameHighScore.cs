using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one row of the high scores table for a game.
    /// </summary>
    public class GameHighScore
    {
        /// <summary>
        /// Position in high score table for the game
        /// </summary>
        public long Position { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Score
        /// </summary>
        public long Score { get; set; }
    }
}
