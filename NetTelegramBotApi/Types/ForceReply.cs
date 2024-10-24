﻿using System.Text.Json.Serialization;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// Upon receiving a message with this object, Telegram clients will display a reply interface to the user
    /// (act as if the user has selected the bot‘s message and tapped ’Reply').
    /// This can be extremely useful if you want to create user-friendly step-by-step interfaces
    /// without having to sacrifice privacy mode.
    /// <see cref="https://core.telegram.org/bots/api#forcereply">See more info on Telegram site</see>.
    /// </summary>
    public class ForceReply : ReplyMarkupBase
    {
        /// <summary>
        /// Shows reply interface to the user, as if they manually selected the bot‘s message and tapped ’Reply'.
        /// </summary>
        /// <remarks>
        /// In original Telegram API, member is called 'ForceReply', but in C# it's forbidden to have properties with same name as class.
        /// </remarks>
        [JsonPropertyName("force_reply")]
        public bool Force { get; set; }

        /// <summary>
        /// Optional. Use this parameter if you want to force reply from specific users only.
        /// Targets:
        ///  1) users that are @mentioned in the text of the Message object;
        ///  2) if the bot's message is a reply (has reply_to_message_id), sender of the original message.
        /// </summary>
        /// <example>
        /// A poll bot for groups runs in privacy mode (only receives commands, replies to its messages and mentions).
        /// There could be two ways to create a new poll:
        ///   1) Explain the user how to send a command with parameters (e.g. /newpoll question answer1 answer2).
        ///       May be appealing for hardcore users but lacks modern day polish.
        ///   2) Guide the user through a step-by-step process. ‘Please send me your question’,
        ///      ‘Cool, now let’s add the first answer option‘, ’Great.
        ///      Keep adding answer options, then send /done when you‘re ready’.
        /// The last option is definitely more attractive. And if you use ForceReply in your bot‘s questions,
        /// it will receive the user’s answers even if it only receives replies, commands and mentions — without any
        /// extra work for the user.
        /// </example>
        public bool Selective { get; set; }
    }
}
