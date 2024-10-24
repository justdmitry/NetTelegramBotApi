﻿namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents a game.
    /// Use BotFather to create and edit games, their short names will act as unique identifiers.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Title of the game.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description of the game.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Photo that will be displayed in the game message in chats.
        /// </summary>
        public PhotoSize[] Photo { get; set; }

        /// <summary>
        /// Optional. Brief description of the game or high scores included in the game message.
        /// Can be automatically edited to include current high scores for the game when the bot calls setGameScore, or manually edited using editMessageText.
        /// 0-4096 characters.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Optional. Special entities that appear in text, such as usernames, URLs, bot commands, etc.
        /// </summary>
        public MessageEntity[] TextEntities { get; set; }

        /// <summary>
        /// Optional. Animation that will be displayed in the game message in chats.
        /// Upload via BotFather.
        /// </summary>
        public Animation Animation { get; set; }
    }
}
