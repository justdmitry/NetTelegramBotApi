using System;

namespace NetTelegramBotApi.Types
{
    /// <summary>
    /// This object represents one special entity in a text message. For example, hashtags, usernames, URLs, etc.
    /// </summary>
    public class MessageEntity
    {
        /// <summary>
        /// Type of the entity.
        /// Can be mention (@username), hashtag, bot_command, url, email, bold (bold text), italic (italic text), code (monowidth string), pre (monowidth block), text_link (for clickable text URLs), text_mention (for users without usernames)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Returns one of <see cref="MessageEntityType"/> members, based on chat <see cref="Type"/> value
        /// </summary>
        /// <returns></returns>
        public MessageEntityType GetMessageEntityType()
        {
            // special case: mention(@username)
            if (Type.StartsWith("mention", StringComparison.OrdinalIgnoreCase))
            {
                return MessageEntityType.Mention;
            }

            switch (Type.ToLowerInvariant())
            {
                case "hashtag":
                    return MessageEntityType.Hashtag;
                case "bot_command":
                    return MessageEntityType.BotCommand;
                case "url":
                    return MessageEntityType.Url;
                case "email":
                    return MessageEntityType.Email;
                case "bold":
                    return MessageEntityType.Bold;
                case "italic":
                    return MessageEntityType.Italic;
                case "code":
                    return MessageEntityType.Code;
                case "pre":
                    return MessageEntityType.Pre;
                case "text_link":
                    return MessageEntityType.TextLink;
                case "text_mention":
                    return MessageEntityType.TextMention;
                default:
                    return MessageEntityType.Unknown;
            }
        }

        /// <summary>
        /// Offset in UTF-16 code units to the start of the entity
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Length of the entity in UTF-16 code units
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Optional. For “text_link” only, url that will be opened after user taps on the text
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Optional. For “text_mention” only, the mentioned user
        /// </summary>
        public User User { get; set; }
    }
}
