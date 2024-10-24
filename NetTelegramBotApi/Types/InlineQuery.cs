﻿namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents an incoming inline query.
    /// When the user sends an empty query, your bot could return some default or trending results.
    /// </summary>
    public class InlineQuery
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Sender
        /// </summary>
        public User From { get; set; }

        /// <summary>
        /// Optional. Sender location, only for bots that request user location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Text of the query (up to 512 characters)
        /// </summary>
        public string Query { get; set; }

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        public string Offset { get; set; }
    }
}
