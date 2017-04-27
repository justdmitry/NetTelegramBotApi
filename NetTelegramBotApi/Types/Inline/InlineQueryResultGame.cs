using System;

namespace NetTelegramBotApi.Types.Inline
{
    public class InlineQueryResultGame : InlineQueryResult
    {
        /// <summary>
        /// Type of the result, must be "game"
        /// </summary>
        public string Type { get; } = "game";

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Short name of the game
        /// </summary>
        public string GameShortName { get; set; }

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
        public InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
